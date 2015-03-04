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
    public class SpeakerController : TableController<SpeakerDto>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new GenericDomainManager<SpeakerDto, Speaker>(context, Request, Services);
        }

        // GET tables/Speaker
        public IQueryable<SpeakerDto> GetAllSpeakerDto()
        {
            return Query(); 
        }

        // GET tables/Speaker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SpeakerDto> GetSpeakerDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Speaker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SpeakerDto> PatchSpeakerDto(string id, Delta<SpeakerDto> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Speaker
        public async Task<IHttpActionResult> PostSpeakerDto(SpeakerDto item)
        {
            SpeakerDto current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Speaker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSpeakerDto(string id)
        {
             return DeleteAsync(id);
        }

    }
}