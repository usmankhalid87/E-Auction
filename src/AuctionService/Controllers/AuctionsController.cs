using AuctionService.Data.Context;
using AuctionService.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AuctionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AuctionDbContext _auctionDbContext;

        public AuctionsController(IMapper mapper,AuctionDbContext auctionDbContext)
        {
            _mapper = mapper;
            this._auctionDbContext = auctionDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
        {
            var auctions =  await _auctionDbContext.Auctions.ToListAsync();
            return _mapper.Map<List<AuctionDto>>(auctions);
        }
    }
}
