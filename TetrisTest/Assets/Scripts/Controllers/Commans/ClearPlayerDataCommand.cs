using strange.extensions.command.impl;
using UnityEngine;

public class ClearPlayerDataCommand : EventCommand
{
    public override void Execute()
    {
        PlayerPrefs.DeleteAll();
    }
}