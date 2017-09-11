using UnityEngine;
using strange.extensions.command.impl;

/// <summary>
/// Startup application simple command;
/// </summary>
public class GetScoreLinesRemovedCommand : EventCommand
{
    public override void Execute()
    {
        int linesCount = (int) evt.data;
        //Score score = AppContext.Instance.RetrieveProxy(Score.NAME) as Score;
        //score.SetScoreFromRemovedLines(linesCount);

        Debug.Log("GetScoreLinesRemovedCommand command executed");
    }
}