
using Microsoft.AspNetCore.Mvc;

namespace EdgePanel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class IBaseController : ControllerBase;
}
