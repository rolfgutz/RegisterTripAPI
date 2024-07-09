using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Register([FromBody]RequestRegisterTripJson request) 
        {
            try
            {
                //request le de onde? from body define que vem do corpo da requisicao 
                var useCase = new RegisterTripUseCase();

                var respose = useCase.Execute(request);


                //Created sem parametro retornar codigo 201
                return Created(string.Empty, respose);
            }
            //deixando sem o parametro lançara qualquer uma excecao.
            //Passando o JourneyException poderar ser capturada e customizada
            catch (JourneyException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro desconhecido");

            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var useCase = new GetAllTripsUseCase();
            var result = useCase.Execute();

            return Ok(result); 

        }


    }
}
