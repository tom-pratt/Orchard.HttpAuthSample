using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyApi.Controllers
{
    [Authorize]
    public class OldValuesController : ApiController
    {
        private readonly IMembershipService _membershipService;

        public OldValuesController(
            IMembershipService membershipService) {
            _membershipService = membershipService;
        }

        private IUser _orchardUser;
        public IUser OrchardUser {
            get {
                if (_orchardUser == null)
                    _orchardUser = _membershipService.GetUser(User.Identity.Name);
                return _orchardUser;
            }
        }

        [Authorize]
        public string Get() {
            return "Hello, you are authorized. Id: " + OrchardUser.Id;
        }
    }
}