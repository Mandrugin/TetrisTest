using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class Score {

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher contextDispatcher { get; set; }

    public int score { get { return _score; } }

    private int _score = 0;

    public Score() {}

    public void SetScoreFromRemovedLines(int linesCount)
    {
        switch (linesCount)
        {
            case 1:
                _score += 100;
                break;
            case 2:
                _score += 300;
                break;
            case 3:
                _score += 500;
                break;
            case 4:
                _score += 800;
                break;
            default:
                Debug.LogError("Unexpected lines count removed");
                break;
        }

        contextDispatcher.Dispatch(NotificationType.SCORE_VIEW_UPDATE_NOTE, _score);
    }
}
