using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById
{
    public class GetTripByIdUseCase
    {

        public ResponseTripJson Execute(Guid id)
        {
            var dbContecxt = new JourneyDbContext();

            var trip = dbContecxt
                .Trips
                .Include(trip=>trip.Activities)
                .FirstOrDefault(x => x.Id == id);

            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
            }



            return new ResponseTripJson
            {
                Id = trip.Id,
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Activities = trip.Activities.Select(actividade =>
                new ResponseActivityJson
                {
                    Name = actividade.Name,
                    Id = actividade.Id,
                    Date = actividade.Date,
                    Status = (Communication.Enums.ActivityStatus)actividade.Status
                }).ToList()
            };
        }
    }
}
