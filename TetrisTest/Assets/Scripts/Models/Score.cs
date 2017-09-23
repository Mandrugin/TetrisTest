using UnityEngine;

public class Score
{
    [Inject]
    public ScoreViewUpdateSignal scoreViewUpdateSignal { get; set; }

    public int score { get { return _score; } }

    private int _score;

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

        scoreViewUpdateSignal.Dispatch(_score);
    }
}
