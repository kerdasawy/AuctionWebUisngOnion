using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AuctionWeb.Service.Features.AuctionFeature.Commands;
using AuctionWeb.Service.Features.AuctionFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWeb.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Auction")]
    [ApiVersion("1.0")]
    public class AuctionController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuctionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

         [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAuctionQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAuctionByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAuctionByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAuctionCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{auctionID} , {bidderID} , {bid}")]
        public async Task<IActionResult> Bid(int auctionID , int bidderID , decimal bid)
        {
            AddBidToAuctionCommand command = new AddBidToAuctionCommand() { AuctionID =auctionID , BidderID = bidderID , Bid= bid };
            return Ok(await Mediator.Send(command));
        }

    }
}
