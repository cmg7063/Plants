using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{
    // This is for the lives Health Bar UI
    //public SpriteRenderer lifeSprite;
    //public Sprite[] sprout;

    public static int scoreNum;
    public static int seedNum;

    public Text healthText;
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
        healthText.text = "Lives: " + Player.health;
        //lifeSprite.sprite = sprout[0];

        seeds.text = "Seeds: " + seedNum;
        score.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update ()
    {
        /*
        healthText.text = "Lives:";
        if(Player.health == 2)
        {
            lifeSprite.sprite = sprout[1];
        }
        if (Player.health == 1)
        {
            lifeSprite.sprite = sprout[2];
        }
        if (Player.health < 1)
        {
            lifeSprite.sprite = null;
        }
        */
        healthText.text = "Lives: " + Player.health;
        seeds.text = "Seeds: " + seedNum;
        score.text = "Score: " + scoreNum;
	}

}
