using InternationalAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> stringLocalizer;
        private readonly IStringLocalizer<ShareResource> _shareResourceLocalizer;
    }
}
