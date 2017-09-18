using strange.extensions.command.impl;
using UnityEngine;

public class GameOverCommand : EventCommand
{
    static readonly string PREFAB_PATH = "GameOverCanvas";

    public override void Execute()
    {
        Object.Instantiate(Resources.Load(PREFAB_PATH));
    }
}