using strange.extensions.command.impl;
using UnityEngine;

public class GameOverCommand : EventCommand
{
    public override void Execute()
    {
        //AppContext.Instance.RegisterMediator(new GameOverMediator());
        Debug.Log("GameOver command executed");
    }
}