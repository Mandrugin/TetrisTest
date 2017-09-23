
public interface IDataSaver
{
    void SaveString(string paramName, string stringToSave);
    string LoadString(string paramName, string defaultValue);
}
