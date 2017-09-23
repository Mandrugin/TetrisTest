using strange.extensions.command.impl;
using UnityEngine;

public class ClearPlayerDataCommand : Command
{
    public override void Execute()
    {
        PlayerPrefs.DeleteAll();
    }
}