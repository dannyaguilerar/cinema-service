namespace Cinema.Core.Exceptions;

public class DuplicateValueException(string name, string value) : Exception($"The property {name} already has a value {value}")
{
    private readonly string propertyName = name;
    public string PropertyName => propertyName;

    private readonly string propertyValue = value;
    public string PropertyValue => propertyValue;
}