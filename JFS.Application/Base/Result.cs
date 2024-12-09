namespace JFS.Application
{
    public class Result
    {
        public string? Error { get; private set; }
        public bool IsSuccess { get; private set; }

        protected Result(bool success = true, string? error = null)
        {
            IsSuccess = success;
            Error = error;
        }

        public static Result Success()
        {
            return new Result();
        }
        public static Result Failure(string? message = null)
        {
            return new Result(false, message);
        }
    }
    public class Result<T> : Result
        where T : class 
    {
        public T Data { get; private set; }

        private Result(T data, bool success = true, string? error = null, string? message = null) : base(success, error)
        {
            Data = data;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }
        public static Result<T> Failure(string? message = null)
        {
            return new Result<T>(null!,false,message);
        }
    }
}
