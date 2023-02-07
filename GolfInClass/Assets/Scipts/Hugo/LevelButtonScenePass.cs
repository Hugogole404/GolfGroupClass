using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class LevelButtonScenePass : MonoBehaviour
{
    [SerializeField] private Button _levelButtonClicked;
    [SerializeField] private Image ImageFade;

    public void OnClickButtonLevel()
    {
        _levelButtonClicked.transform.DOComplete();
        _levelButtonClicked.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeLevelClick);
    }

    public void FadeLevelClick()
    {
        SceneManager.LoadScene("Level_" + _levelButtonClicked.name);
    }
}