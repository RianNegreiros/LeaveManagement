using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize(Roles = "Administrator")]
  public class LeaveTypesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
      var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
      return Ok(leaveTypes);
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
      var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
      return Ok(leaveType);
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
      var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
      var repsonse = await _mediator.Send(command);
      return Ok(repsonse);
    }

    // PUT api/<LeaveTypesController>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
      var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };
      await _mediator.Send(command);
      return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var command = new DeleteLeaveTypeCommand { Id = id };
      await _mediator.Send(command);
      return NoContent();
    }
  }
}