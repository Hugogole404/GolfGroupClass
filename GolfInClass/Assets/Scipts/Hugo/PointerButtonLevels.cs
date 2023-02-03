using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class PointerButtonLevels : MonoBehaviour
{
    [SerializeField] private Button ButtonLevel1;
    private Vector3 _originalScale;
    private Vector3 _newScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        _newScale = _originalScale * 1.1f;
    }

    public void OnPointerEnter()
    {
        if (_hidden)
            return;

        ButtonLevel1.transform.DOKill();
        ButtonLevel1.transform.DOScale(_newScale, 0.3f);
        
    }
    public void OnpointerExit()
    {

        ButtonLevel1.transform.DOKill();
        ButtonLevel1.transform.DOScale(_originalScale, 0.3f);
        
    }
    public void Hide()
    {
        _hidden = true;
    }
    bool _hidden = false;
}
