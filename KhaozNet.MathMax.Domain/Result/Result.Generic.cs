namespace KhaozNet.MathMax.Domain.Result
{
    public class Result<T> : Result
    {
        public T Value { get; set; }

        public Result(bool isSuccess, T value, string exceptionMessage) : base(isSuccess, exceptionMessage)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Success: {IsSuccess}, ExceptionMessage: {ExceptionMessage}";
        }
    }
}
