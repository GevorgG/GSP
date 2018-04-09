using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniSenseNetwork.GSP.ClientAPI.Attributes;
using OmniSenseNetwork.GSP.ClientAPI.Models;

namespace OmniSenseNetwork.GSP.ClientAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [TokenAuthorization]
    public class ClientsController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Credentials credentials)
        {
            //TODO
            return Ok();
        }
    }
}
