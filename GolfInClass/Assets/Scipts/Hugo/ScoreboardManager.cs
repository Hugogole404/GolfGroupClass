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
    public TextMeshProUGUI names, putts;
    private PlayerRecords playerRecords;

    private void Start()
    {
        playerRecords = GameObject.Find("PlayerRecord").GetComponent<PlayerRecords>();
        names.text = "";
        putts.text = "";
        foreach (var player in playerRecords.GetScoreboardList())
        {
            names.text += player.name + "\n";
            putts.text += player.totalPutts + "\n";
        }
    }
    private void Update()
    {
        putts.fontSize = names.fontSize;
    }
    public void ButtonReturnMenu()
    {
        Destroy(playerRecords.gameObject);
    }
}
