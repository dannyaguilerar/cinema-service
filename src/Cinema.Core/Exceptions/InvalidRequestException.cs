namespace Cinema.Core.Exceptions
{
    public class InvalidRequestException(string name, IDictionary<string, string[]> errors) : Exception($"Invalid request {name} with {errors.Count} errors.")
    {
        private readonly string modelName = name;
        public string ModelName => modelName;

        private readonly IDictionary<string, string[]> modelErrors = errors;
        public IDictionary<string, string[]> ModelErrors => modelErrors;
    }
}
