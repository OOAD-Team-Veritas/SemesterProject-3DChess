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
    private int minutes, seconds;
    private string timeStr;
    private float elpasedTime = 0;
    public GameObject gameTimerTxt;
    public bool whiteTurn;
    
    void Start()
    {
        //Player 1 always goes first
        whiteTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        elpasedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elpasedTime / 60f);
        seconds = Mathf.FloorToInt(elpasedTime - minutes * 60);
        timeStr = string.Format("{0:00}:{1:00}", minutes, seconds);
        gameTimerTxt.GetComponent<Text>().text = timeStr;
    }


}
