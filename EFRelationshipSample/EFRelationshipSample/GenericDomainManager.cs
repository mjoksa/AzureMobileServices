using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample
{
    public class GenericDomainManager<TDto, TModel>:
        MappedEntityDomainManager<TDto,TModel> 
        where TDto : EntityData
        where TModel : EntityData
    {
        public GenericDomainManager(DbContext context, HttpRequestMessage request, ApiServices services) : base(context, request, services)
        {
        }

        public GenericDomainManager(DbContext context, HttpRequestMessage request, ApiServices services, bool enableSoftDelete) : base(context, request, services, enableSoftDelete)
        {
        }
        protected override void SetOriginalVersion(TModel model, byte[] version)
        {
            Context.Entry(model).OriginalValues["Version"] = version;
        }
        public override SingleResult<TDto> Lookup(string id)
        {
            return LookupEntity(c => c.Id == id);
        }

        public override async Task<TDto> UpdateAsync(string id, Delta<TDto> patch)
        {
             return await base.UpdateEntityAsync(patch,id);
        }

        public override async Task<bool> DeleteAsync(string id)
        {
            return await DeleteItemAsync(id);
        }
    }
}
