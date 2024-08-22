using AutoMapper;
using Dijkstra.Api.Dtos;
using Dijkstra.Core.Model;

namespace Dijkstra.Api.Profiles
{
    public class ShortestPathProfile: Profile
    {
        public ShortestPathProfile()
        {
            CreateMap<ShortestPathData, ShortestPathDataDto>().ReverseMap();
        }
    }
}
