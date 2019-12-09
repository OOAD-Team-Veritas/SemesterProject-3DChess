using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulatePlayerNames : MonoBehaviour
{
    public GameObject PlayerOneTxt;
    public GameObject PlayerTwoTxt;
    public PlayerNames playernames;
    void Start()
    {
        playernames = GameObject.Find("PersistentGameObject").GetComponent<PlayerNames>();
        PlayerOneTxt.GetComponent<Text>().text = playernames.playerOne;
        PlayerTwoTxt.GetComponent<Text>().text = playernames.playerTwo;

    }
}
