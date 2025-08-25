using CRUD2.Models;

namespace CRUD2.Data.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;

        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<CarDto>> GetCarsAsync()
        {
           var response = await _httpClient.GetFromJsonAsync<NhtsaResponse>("vehicles/GetMakesForVehicleType/car?format=json");
            if (response?.Results == null)
            {
                return new List<CarDto>();
            }
            return response.Results.Select(r => new CarDto
            {
                MakeId = r.MakeId,
                MakeName = r.MakeName
            }).ToList();
        }
    }
}
