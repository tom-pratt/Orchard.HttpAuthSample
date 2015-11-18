using Orchard;
using System.Web.Http;
using Orchard.Core.Contents;

namespace HttpAuth.Controllers
{
    public class ValuesController : ApiController {
        private readonly IOrchardServices _orchardServices;

        public ValuesController(IOrchardServices orchardServices) {
            _orchardServices = orchardServices;
        }

        public IHttpActionResult Get() {
            if (!_orchardServices.Authorizer.Authorize(Permissions.DeleteContent))
                return Unauthorized();

            return Ok("Your ID is " + _orchardServices.WorkContext.CurrentUser.Id + " and you are authorized to delete content");
        }
    }
}