using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using safgs.Service;
using safgs.DTO.Publishers;

namespace safgs.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publisherService;

        public PublishersController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherModel>>> GetAllPublishersAsync()
        {
            return Ok(await _publisherService.GetAllPublishersAsync());
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPublisherAsync([FromBody] PublisherModel publisher)
        {
            int id = await _publisherService.AddPublisherAsync(publisher);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePublisherAsync([FromBody] PublisherModel publisher)
        {
            await _publisherService.UpdatePublisherAsync(publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublisherAsync(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}