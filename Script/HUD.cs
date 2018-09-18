using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;

    public int score;
    public Text ScoreTextDisplay;

    public GameObject titleScreen;


    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }
    public void UpdateScore()
    {
        score += 1;
        ScoreTextDisplay.text = "SCORE : " + score;
    }
    public void showTitle()
    {
        titleScreen.SetActive(true);

    }
    public void hideTitle()
    {
        titleScreen.SetActive(false);
        ScoreTextDisplay.text = "SCORE : 000" ;

    }
}
