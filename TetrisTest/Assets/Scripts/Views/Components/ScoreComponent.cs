using UnityEngine;
using UnityEngine.UI;

public class ScoreComponent : MonoBehaviour {

    public Text ScoreText;
    
    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
}
