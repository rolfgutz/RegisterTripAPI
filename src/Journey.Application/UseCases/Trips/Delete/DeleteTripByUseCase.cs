using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteTripByUseCase
    {

        public void Execute(Guid id)
        {
            var dbContecxt = new JourneyDbContext();

            var trip = dbContecxt
                .Trips
                .Include(trip => trip.Activities)
                .FirstOrDefault(x => x.Id == id);

            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
            }

            dbContecxt.Trips.Remove(trip);
            dbContecxt.SaveChanges();

        }
    }
}
