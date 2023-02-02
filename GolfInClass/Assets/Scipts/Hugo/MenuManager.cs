using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Menu menu;

    [Header("Player Name")]
    public TMP_InputField inputPlayerName;
    public PlayerRecords playerRecords;
    public Button buttonStart;
    public Button buttonAddPlayer;
    public GameObject ButtonConfirm;


    #region Player's name
    public void ButtonAddPlayer()
    {
        ButtonConfirm.transform.DOComplete();
        ButtonConfirm.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        playerRecords.AddPlayer(inputPlayerName.text);
        buttonStart.interactable = true;
        inputPlayerName.text = "";

        if (playerRecords.playerList.Count == playerRecords.playerColours.Length)
        {
            buttonAddPlayer.interactable = false; 
        }
    }
    #endregion

    public void ButtonStart()
    {
        //SceneManager.LoadScene(playerRecords.levels[0]);
        menu.OnCLickOnPlay();
    }
}
