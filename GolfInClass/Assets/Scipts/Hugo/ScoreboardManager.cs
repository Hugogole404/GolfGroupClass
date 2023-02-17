using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScoreboardManager : MonoBehaviour
{
    public TextMeshProUGUI names, putts, total;
    private PlayerRecords playerRecords;

    private void Start()
    {
        playerRecords = GameObject.Find("_PlayerRecords").GetComponent<PlayerRecords>();
        names.text = "";
        putts.text = "";
        total.text = "";
        foreach (var player in playerRecords.GetScoreboardList())
        {
            names.text += player.name + "\n";
            total.text = "Total : ";
            putts.text += player.totalPutts + "\n";
        }
    }
    private void Update()
    {
        putts.fontSize = names.fontSize;
        total.fontSize = names.fontSize;
    }
    public void ButtonReturnMenu()
    {
        Destroy(playerRecords.gameObject);
    }
}