using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class FirstSceneTitle : MonoBehaviour
{
    [SerializeField] private Button ButtonTitle;
    [SerializeField] private Image ImageFade;
    public void OnClickAnyKey()
    {
        ButtonTitle.transform.DOComplete();
        ButtonTitle.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeButtonTitle);
    }

    public void FadeButtonTitle()
    {
        SceneManager.LoadScene("Menu");
    }
}
