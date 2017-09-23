using UnityEngine;

public class PlayerStats
{
    public int MaxScore;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }
}
