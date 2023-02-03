using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Menu : MonoBehaviour
{
    //[Header("Player Name")]
    //public TMP_InputField inputPlayerName;
    //public PlayerRecords playerRecords;
    //public Button buttonStart;

    [Header ("Les Boutons")]
    [SerializeField] private List<Button> ButtonsMenu;
    [SerializeField] private GameObject ButtonPlay;
    [SerializeField] private GameObject ButtonLevels;
    [SerializeField] private GameObject ButtonCredits;
    [SerializeField] private GameObject ButtonMenu;
    [SerializeField] private GameObject ButtonQuit;
    [SerializeField] private TMPro.TextMeshProUGUI Text;

    [Header("Le Fade")]
    [SerializeField] private Image ImageFade;
    //[SerializeField] private Image ImageOutline;
    //[SerializeField] private Image ImageScale;
    [SerializeField] private Color ColorInitial;
    [SerializeField] private Color ColorSelected;

    //#region Player's name
    //public void ButtonAddPlayer()
    //{
    //    playerRecords.AddPlayer(inputPlayerName.text);
    //    buttonStart.interactable = true;
    //}
    //#endregion


    #region ClickDesBoutons
    public void OnCLickOnPlay()
    {
        ButtonPlay.transform.DOComplete();
        ButtonPlay.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadePlayComplete);
    }    
    public void OnCLickOnLevels()
    {
        ButtonLevels.transform.DOComplete();
        ButtonLevels.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeLevelsComplete);
    }    
    public void OnCLickOnCredits()
    {
        ButtonCredits.transform.DOComplete();
        ButtonCredits.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeCreditsComplete);
    }    
    public void OnCLickOnMenu()
    {
        ButtonMenu.transform.DOComplete();
        ButtonMenu.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeMenuComplete);
    }    
    public void OnCLickOnQuit()
    {
        ButtonQuit.transform.DOComplete();
        ButtonQuit.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeQuitComplete);
    }
    #endregion

    #region Fade
    public void FadePlayComplete()
    {
        SceneManager.LoadScene("MainGame");
    }    
    public void FadeCreditsComplete()
    {
        SceneManager.LoadScene("Credits");
    }
    public void FadeLevelsComplete()
    {
        SceneManager.LoadScene("SelectLevels");
    }    
    public void FadeMenuComplete()
    {
        SceneManager.LoadScene("Menu");
    }    
    public void FadeQuitComplete()
    {
        Application.Quit();
    }
    #endregion
}
