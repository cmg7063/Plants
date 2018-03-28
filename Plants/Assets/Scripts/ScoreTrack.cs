using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{

    public static int scoreNum;
    public Text score;
    public Text seeds;

    public int Score
    {
        get { return scoreNum; }
        set { scoreNum = value; }
    }

    // Use this for initialization
    void Start ()
    {
        scoreNum = 0;
        score.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update ()
    {
		score.text = "Score: " + scoreNum;
	}

}
