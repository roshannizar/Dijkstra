using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Dijkstra.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public readonly IMapper mapper;

        public BaseApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
