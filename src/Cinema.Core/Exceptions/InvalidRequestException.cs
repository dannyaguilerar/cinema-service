namespace Cinema.Core.Exceptions
{
    public class InvalidRequestException : Exception
    {
        private readonly string modelName;
        public string ModelName => modelName;

        private readonly IDictionary<string, string[]> modelErrors;
        public IDictionary<string, string[]> ModelErrors => modelErrors;

        public InvalidRequestException(string name, IDictionary<string, string[]> errors) : base($"Invalid request {name} with {errors.Count} errors.")
        {
            modelName = name;
            modelErrors = errors;
        }
    }
}
