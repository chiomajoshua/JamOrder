namespace JamOrder.Data.Models
{
    public class GenericResponse<T>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}