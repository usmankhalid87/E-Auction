using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuctionsController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
