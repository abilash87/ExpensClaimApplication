namespace ExpenseClaimApplication.Model
{
    public class ApiResponse<T>
    {
        public T Data { get; }
        public bool Success { get; }
        public string ErrorMessage { get; }

        public ApiResponse(T data, bool success = true, string errorMessage = null)
        {
            Data = data;
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
