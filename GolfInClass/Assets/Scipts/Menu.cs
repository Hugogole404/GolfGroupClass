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
    [SerializeField]public List<Button> ButtonsMenu;
    [SerializeField] public TMPro.TextMeshProUGUI Text;

    [Header("Le Fade")]
    [SerializeField] public Image ImageFade;
    [SerializeField] public Image ImageOutline;
    [SerializeField] public Image ImageScale;
    [SerializeField] public Color ColorInitial;
    [SerializeField] public Color ColorSelected;

    #region Pointer
    public void OnPointerEnter()
    {
        if (_hidden)
            return;
        ImageOutline.DOKill();
        ImageOutline.DOFade(1, 0.3f);

        Text.DOKill();
        Text.DOColor(ColorSelected, 0.3f);
    }    
    public void OnPointerExit()
    {
        ImageOutline.DOKill();
        ImageOutline.DOFade(0, 0.2f);

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

    #endregion

    #region Fade
    public void FadePlay()
    {

    }    
    public void FadeCredit()
    {

    }    
    public void FadeLevel()
    {

    }    
    public void Fade()
    {

    }    
    public void FadeQuit()
    {

    }
    #endregion
}
