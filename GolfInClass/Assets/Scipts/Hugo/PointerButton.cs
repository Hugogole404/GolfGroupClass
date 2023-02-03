using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class PointerButton : MonoBehaviour
{
    //[SerializeField] private Button[] button;
    [SerializeField] private Button ButtonTest;
    private Vector3 _originalScale;
    private Vector3 _newScale;

    private void Start()
    {
        _originalScale = transform.localScale * 0.4166667f;
        _newScale = _originalScale * 1.1f;
    }

    public void OnPointerEnter()
    {
        if (_hidden)
            return;
        transform.DOKill();
        ButtonTest.transform.DOScale(_newScale, 0.3f);
    }
    public void OnPointerExit()
    {
        transform.DOKill();
        ButtonTest.transform.DOScale(_originalScale, 0.3f);
    }
    public void Hide()
    {
        _hidden = true;
    }
    bool _hidden = false;
}
