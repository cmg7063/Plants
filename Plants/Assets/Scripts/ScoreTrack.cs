using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{

    public static int scoreNum;
    public static int seedNum;
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
        seedNum = 0;
        score.text = "Seeds: " + seedNum + "\nScore: " + score;
    }

    // Update is called once per frame
    void Update ()
    {
		score.text = "Seeds: " + seedNum + "\nScore: " + scoreNum;
	}

}
