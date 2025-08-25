using CRUD2.Models;

namespace CRUD2.Data.Services
{
    public interface ICarService
    {
        Task<List<CarDto>> GetCarsAsync();
    }
}
