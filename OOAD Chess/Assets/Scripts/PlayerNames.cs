using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNames : MonoBehaviour
{
    public string playerOne;
    public string playerTwo;
    public GameObject playerOneNameTxt;
    public GameObject playerTwoNameTxt;

    public void retrievePlayerNames()
    {
        playerOne = playerOneNameTxt.GetComponent<Text>().text;
        playerTwo = playerTwoNameTxt.GetComponent<Text>().text;
        Debug.Log(playerOne + playerTwo);
    }
}
