using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {

        public ResponseShortTripJson Execute(RequestRegisterTripJson request)
        {
            Validate(request);
            var dbContecxt = new JourneyDbContext();

            var entity = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,

            };

            dbContecxt.Trips.Add(entity);
            dbContecxt.SaveChanges();

            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
                Id = entity.Id
            };

        }

        private void Validate(RequestRegisterTripJson request)
        {

            var validator = new RegisterTripValidator();

            var result =  validator.Validate(request);   

           if (result.IsValid== false) 
           {
                var errorMessage = result.Errors.Select(erro => erro.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage); 
           }

        }

    }
}
