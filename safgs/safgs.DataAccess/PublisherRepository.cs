namespace safgs
{
    using safgs.DTO.Publishers;
    public class PublisherRepository : IPublisherRepository
    {
        private readonly string _connectionString;
        public PublisherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PublisherModel>> GetAllPublishersAsync()
        {
            List<PublisherModel> list = new List<PublisherModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Publishers", connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var publisher = new PublisherModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2)
                            };
                            list.Add(publisher);
                        }
                    }
                }
            }

            return list;
        }

        public async Task<int> AddPublisherAsync(PublisherModel publisher)
        {
            int id;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO Publishers (Name, Address) VALUES (@name, @address); SELECT CAST(SCOPE_IDENTITY() as int)", connection))
                {
                    command.Parameters.AddWithValue("@name", publisher.Name);
                    command.Parameters.AddWithValue("@address", publisher.Address);

                    id = (int)await command.ExecuteScalarAsync();
                }
            }

            return id;
        }

        public async Task UpdatePublisherAsync(PublisherModel publisher)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("UPDATE Publishers SET Name = @name, Address = @address WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@name", publisher.Name);
                    command.Parameters.AddWithValue("@address", publisher.Address);
                    command.Parameters.AddWithValue("@id", publisher.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePublisherAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM Publishers WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}