using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AuctionWeb.Service.Features.ItemFeature.Commands;
using AuctionWeb.Service.Features.ItemFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWeb.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/item")]
    [ApiVersion("1.0")]
    public class ItemController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

         [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllItemQuery()));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetItemByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteItemByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
