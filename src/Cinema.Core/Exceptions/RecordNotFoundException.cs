namespace Cinema.Core.Exceptions;

public class RecordNotFoundException(string name, string id) : Exception($"Record '{name}' with Id '{id}' does not exist.")
{
    private readonly string recordName = name;
    public string RecordName => recordName;

    private readonly string recordId = id;
    public string RecordId => recordId;
}
