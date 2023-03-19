namespace ConsoleApp1
{
    public class ApiResponseModel<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}