namespace safgs.Service
{
    using safgs.DataAccess;
    using safgs.DTO.Publishers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PublishersService : IPublishersService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<PublisherModel>> GetAllPublishersAsync()
        {
            return await _publisherRepository.GetAllPublishersAsync();
        }

        public async Task<int> AddPublisherAsync(PublisherModel publisher)
        {
            return await _publisherRepository.AddPublisherAsync(publisher);
        }

        public async Task UpdatePublisherAsync(PublisherModel publisher)
        {
            await _publisherRepository.UpdatePublisherAsync(publisher);
        }

        public async Task DeletePublisherAsync(int id)
        {
            await _publisherRepository.DeletePublisherAsync(id);
        }
    }
}