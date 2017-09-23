using UnityEngine;

public class DataSaver : IDataSaver
{
    public string LoadString(string paramName, string defaultValue)
    {
        var _dataString = PlayerPrefs.GetString(paramName, defaultValue);
        Debug.Log("<color=green>Load string[" + paramName + " : " + _dataString + "</color>]");
        return _dataString;
    }

    public void SaveString(string paramName, string stringToSave)
    {
        Debug.Log("<color=green>Save string[" + paramName + " : " + stringToSave + "</color>]");
        PlayerPrefs.SetString(paramName, stringToSave);
    }
}
