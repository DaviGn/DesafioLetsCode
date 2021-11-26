namespace API.Domain
{
    public class JsonError
    {
        public JsonError()
        {
        }

        public JsonError(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public string Field { get; set; }
        public string Message { get; set; }
    }
}