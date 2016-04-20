using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private Text text;

    public int score = 0;

    void Start()
    {
        text = GetComponent<Text>();
        Reset();
    }

    public void Score(int points)
    {
        score += points;
        text.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        text.text = score.ToString();
    }
}
