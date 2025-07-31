using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.API.Controllers
{
    //   [Route("api/[controller ]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
        public StudentController(IMediator mediator):base(mediator)
        {
            
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginate([FromQuery]GetStudentPaginatedListQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok( response);
        }



        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            var response =  await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok( response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create(AddStudentCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            var res = NewResult(await _mediator.Send(command));
            return res;
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
           
            var res = NewResult(await _mediator.Send(new DeleteStudentCommand (id)));
            return res;
        }
    }
}
