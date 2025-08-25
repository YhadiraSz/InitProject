namespace CRUD2.Models
{
    public class NhtsaResponse
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<CarDto>? Results { get; set; }
    }
}
