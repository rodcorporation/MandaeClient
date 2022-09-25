namespace MandaeClient
{
    public class ApiResponse<T> where T : class
    {
        public T Response { get; private set; }
        public ErrorResponse Error { get; private set; }
        public bool IsSuccess => Error == null;

        public ApiResponse(T response)
        {
            Response = response;
        }

        public ApiResponse(ErrorResponse error)
        {
            Error = error;
        }
    }
}
