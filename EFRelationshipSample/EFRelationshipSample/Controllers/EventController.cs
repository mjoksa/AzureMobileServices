using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using EFRelationshipSample.DataObjects;
using EFRelationshipSample.Models;

namespace EFRelationshipSample.Controllers
{
    public class EventController : TableController<EventDto>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new GenericDomainManager<EventDto, Event>(context, Request, Services);
        }

        // GET tables/Event
        public IQueryable<EventDto> GetAllEventDto()
        {
            return Query(); 
        }

        // GET tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EventDto> GetEventDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EventDto> PatchEventDto(string id, Delta<EventDto> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Event
        public async Task<IHttpActionResult> PostEventDto(EventDto item)
        {
            EventDto current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEventDto(string id)
        {
             return DeleteAsync(id);
        }

    }
}