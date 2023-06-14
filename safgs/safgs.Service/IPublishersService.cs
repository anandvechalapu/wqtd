namespace safgs.Service
{
    using safgs.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPublishersService
    {
        Task<IEnumerable<PublisherModel>> GetAllPublishersAsync();
        Task<int> AddPublisherAsync(PublisherModel publisher);
        Task UpdatePublisherAsync(PublisherModel publisher);
        Task DeletePublisherAsync(int id);
    }
}