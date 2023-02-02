using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class PointerButtons : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI Text;
    [SerializeField] private Color ColorInitial;
    [SerializeField] private Color ColorSelected;
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button ButtonLevels;
    [SerializeField] private Button ButtonCredits;
    [SerializeField] private Button ButtonMenu;
    [SerializeField] private Button ButtonQuit;
    private Vector3 OriginSize;
    private Vector3 NextSize;

    #region Pointer
    public void OnPointerEnterPlay()
    {
        OriginSize = transform.localScale;
        NextSize = OriginSize * 1.2f;

        if (_hidden)
            return;
        //ImageOutline.DOKill();
        //ImageOutline.DOFade(1, 0.3f);

        Text.DOKill();
        //Text.DOColor(ColorSelected, 0.3f);
        ButtonPlay.transform.DOScale(NextSize, 0.5f);

    }
    public void OnPointerExitPlay()
    {
        //ImageOutline.DOKill();
        //ImageOutline.DOFade(0, 0.2f);

        Text.DOKill();
        //Text.DOColor(ColorInitial, 0.2f);
        ButtonPlay.transform.DOScale(OriginSize, 0.5f);
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
}
