using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour {

    public static int scoreNum;
    Text score;

	// Use this for initialization
	void Start () {
        scoreNum = 0;
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + scoreNum;
	}
}
