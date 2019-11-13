using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Source for using string format
 * https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
 */

public class ChessGameTimer : MonoBehaviour
{
    private float gameTime, player1Time, player2Time;
    
    public GameObject gameTimerTxt;
    public GameObject player1TimerTxt;
    public GameObject player2TimerTxt;
    public bool whiteTurn;
    
    void Start()
    {
        //Player 1 always goes first
        whiteTurn = true;
        gameTime = 0;
        player1Time = 0;
        player2Time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //time in seconds since the last frame
        gameTime += Time.deltaTime;
        gameTimerTxt.GetComponent<Text>().text = formatTimeString(gameTime);

        if (whiteTurn)
        {
            player1Time += Time.deltaTime;
            player1TimerTxt.GetComponent<Text>().text = formatTimeString(player1Time);
        }
        else
        {
            player2Time += Time.deltaTime;
            player2TimerTxt.GetComponent<Text>().text = formatTimeString(player2Time);
        }
    }

    private string formatTimeString(float time)
    {
        int minutes, seconds;
        minutes = Mathf.FloorToInt(time / 60f);
        seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
