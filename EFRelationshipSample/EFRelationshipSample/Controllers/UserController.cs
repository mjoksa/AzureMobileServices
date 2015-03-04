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
    public class UserController : TableController<UserDto>
    {
        private MobileServiceContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new MobileServiceContext();
            DomainManager = new GenericDomainManager<UserDto, User>(_context, Request, Services);
        }

        // GET tables/User
        public IQueryable<UserDto> GetAllUserDto()
        {
            return Query(); 
        }

        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserDto> GetUserDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserDto> PatchUserDto(string id, Delta<UserDto> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/User
        public async Task<IHttpActionResult> PostUserDto(UserDto item)
        {
            UserDto current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserDto(string id)
        {
             return DeleteAsync(id);
        }

    }
}