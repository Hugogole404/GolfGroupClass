using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class ButtonsLevelChoice : MonoBehaviour
{
    //[SerializeField] private List<GameObject> ButtonList;
    [SerializeField] private Button[] _buttonlevelsChoice;
    
    public void ClickOnButtonLevel_1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void ClickOnButtonLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void ClickOnButtonLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void ClickOnButtonLevel_4()
    {
        SceneManager.LoadScene("Level_4");
    }
    public void ClickOnButtonLevel_5()
    {
        SceneManager.LoadScene("Level_5");
    }
    public void ClickOnButtonLevel_6()
    {
        SceneManager.LoadScene("Level_6");
    }
    public void ClickOnButtonLevel_7()
    {
        SceneManager.LoadScene("Level_7");
    }
    public void ClickOnButtonLevel_8()
    {
        SceneManager.LoadScene("Level_8");
    }
    public void ClickOnButtonLevel_9()
    {
        SceneManager.LoadScene("Level_9");
    }
    public void ClickOnButtonLevel_10()
    {
        SceneManager.LoadScene("Level_10");
    }
}
