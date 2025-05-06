using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;
using Petfolio.Application.UseCases.Pets.DeleteById;

namespace Petfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestPetJson request)
        {
            var useCase = new RegisterPetUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }


        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
        {
            var useCase = new UpdatePetUseCase();
            useCase.Execute(id, request);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllPetsUseCase();
            var res = useCase.Execute();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
           var useCase = new GetPetByIdUseCase();
           var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteById(int id) {
            var useCase = new DeletePetByIdUseCase();
            useCase.Execute(id);

            return NoContent();
        }
    }
}
