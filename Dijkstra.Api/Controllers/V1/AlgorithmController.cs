using AutoMapper;
using Dijkstra.Api.Dtos;
using Dijkstra.Core.Model;
using Dijkstra.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dijkstra.Api.Controllers.V1
{
    [Route("api/v1/algorithm")]
    [ApiController]
    public class AlgorithmController : BaseApiController
    {
        private readonly IAlgorithmService algorithmService;

        public AlgorithmController(IAlgorithmService algorithmService, IMapper mapper) : base(mapper)
        {
            this.algorithmService = algorithmService;
        }

        [HttpGet]
        public ActionResult<ShortestPathDataDto> GetDistance(string fromNode, string toNode)
        {
            var response = algorithmService.ShortestPath(fromNode, toNode, new Nodes().InitializeData());
            var mappedResponse = mapper.Map<ShortestPathDataDto>(response);
            return Ok(mappedResponse);
        }

    }
}
