using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class ScoreView : EventView {

    public Text ScoreText;
    
    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
}
