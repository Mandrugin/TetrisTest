using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

/// <summary>
/// Startup application simple command;
/// </summary>
public class GetScoreLinesRemovedCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        int linesCount = (int)notification.Body;
        ScoreProxy scoreProxy = AppFacade.Instance.RetrieveProxy(ScoreProxy.NAME) as ScoreProxy;
        scoreProxy.SetScoreFromRemovedLines(linesCount);

        Debug.Log("GetScoreLinesRemovedCommand command executed");
    }
}