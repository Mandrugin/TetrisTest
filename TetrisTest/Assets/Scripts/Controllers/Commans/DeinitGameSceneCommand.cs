using strange.extensions.command.impl;
using UnityEngine;

class DeinitGameSceneCommand : EventCommand
{
    public override void Execute()
    {
        Debug.Log("DeinitGameSceneCommand Executing");
    }
}
