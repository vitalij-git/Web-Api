using WarehouseStore.Database;
using WarehouseStore.Models.Dto;

namespace WarehouseStore.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbContextService _dbContextService;

        public ReservationRepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }

        public async Task AddReservation(ReservationDto reservationDto)
        {

        }
    }
}
