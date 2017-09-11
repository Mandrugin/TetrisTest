using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class Score {

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    private IEventDispatcher contextDispatcher { get; set; }

    private int score = 0;

    public Score() {}

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

        contextDispatcher.Dispatch(NotificationType.SCORE_VIEW_UPDATE_NOTE, score);
    }
}
