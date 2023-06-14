namespace safgs.Service
{
    using safgs.DTO.Publishers;
    public interface IPublisherRepository
    {
        Task<IEnumerable<PublisherModel>> GetAllPublishersAsync();
        Task<int> AddPublisherAsync(PublisherModel publisher);
        Task UpdatePublisherAsync(PublisherModel publisher);
        Task DeletePublisherAsync(int id);
    }
}