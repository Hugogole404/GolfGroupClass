using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header ("Les Boutons")]
    [SerializeField] private List<Button> ButtonsMenu;
    [SerializeField] private TMPro.TextMeshProUGUI Text;

    [Header("Le Fade")]
    [SerializeField] private Image ImageFade;
    //[SerializeField] private Image ImageOutline;
    //[SerializeField] private Image ImageScale;
    [SerializeField] private Color ColorInitial;
    [SerializeField] private Color ColorSelected;

    #region Pointer
    public void OnPointerEnter()
    {
        if (_hidden)
            return;
        //ImageOutline.DOKill();
        //ImageOutline.DOFade(1, 0.3f);

        Text.DOKill();
        Text.DOColor(ColorSelected, 0.3f);
    }    
    public void OnPointerExit()
    {
        //ImageOutline.DOKill();
        //ImageOutline.DOFade(0, 0.2f);

        Text.DOKill();
        Text.DOColor(ColorInitial, 0.2f);
    }    
    public void Hide()
    {
        //ImageOutline.DOKill();
        //ImageOutline.DOFade(0, time);

        //Text.DOKill();
        //Text.DOFade(0, time);

        _hidden = true;
    }
    bool _hidden = false;
    #endregion

    #region ClickDesBoutons
    public void OnCLickOnPlay()
    {

    }    
    public void OnCLickOnLevels()
    {

    }    
    public void OnCLickOnCredits()
    {

    }    
    public void OnCLickOnMenu()
    {

    }    
    public void OnCLickOnQuit()
    {

    }
    #endregion

    #region Fade
    public void FadePlayComplete()
    {

    }    
    public void FadeCreditsComplete()
    {

    }    
    public void FadeLevelComplete()
    {

    }    
    public void FadeMenuComplete()
    {

    }    
    public void FadeQuitComplete()
    {

    }
    #endregion
}
