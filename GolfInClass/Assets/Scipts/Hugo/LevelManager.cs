using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public BallController ball;
    public TextMeshProUGUI labelPlayerName;

    private int playerIndex;
    private PlayerRecords playerRecords;

    private void Start()
    {
        playerRecords = GameObject.Find("_PlayerRecords").GetComponent<PlayerRecords>();
        playerIndex = 0;
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        ball.SetupBall(playerRecords.playerColours[playerIndex]);
        labelPlayerName.text = playerRecords.playerList[playerIndex].name;
    }

    public void NextPlayer(int previousPutts)
    {

    }
}
