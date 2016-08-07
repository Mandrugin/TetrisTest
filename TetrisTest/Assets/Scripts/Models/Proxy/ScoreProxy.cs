using UnityEngine;
using PureMVC.Patterns;

public class ScoreProxy : Proxy {

    new public const string NAME = "ScoreProxy";
    private int score = 0;

    public ScoreProxy() : base(NAME) {}

    public void SetScoreFromRemovedLines(int linesCount)
    {
        switch (linesCount)
        {
            case 1:
                score += 100;
                break;
            case 2:
                score += 300;
                break;
            case 3:
                score += 500;
                break;
            case 4:
                score += 800;
                break;
            default:
                Debug.LogError("Unexpected lines count removed");
                break;
        }

        AppFacade.Instance.SendNotification(NotificationType.SCORE_VIEW_UPDATE_NOTE, score);
    }
}
