using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class Test : MonoBehaviour
{
    [SerializeField] private Button _levelButtonClicked;

    public void OnClickButtonLevel()
    {
        SceneManager.LoadScene("Level_" + _levelButtonClicked.name);
    }
}