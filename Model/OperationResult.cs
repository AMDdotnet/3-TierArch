namespace Model
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public static OperationResult Success() => new OperationResult { IsSuccess = true };
        public static OperationResult Failure(string message) => new OperationResult { Message = message };

    }
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>
            {
                IsSuccess = true,
                Data = data
            };
        }
        public static new OperationResult<T> Failure(string message) => new OperationResult<T> { Message = message };
    }
}
