using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**Source: Youtube by Coco Code 
 * 
 * https://www.youtube.com/watch?v=YUcvy9PHeXs
 * NOT ADDED YET TO SCENE AND ONLY JUST ADDED TO ASSETS.SCRIPTS
 * Note this is a place holder for score points and highest score
 * * Added to Comp391 Group Project Assets by Jonathan Bonda 301288990 20230313
 * **/


public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGH SCORE:  " + highScore.ToString();

    }

    
    public void AddPoint()
    {
        score = +1;
        scoreText.text = score.ToString() + " POINTS";



    }

}
