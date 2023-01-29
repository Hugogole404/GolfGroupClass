using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Feedbacks : MonoBehaviour
{
    BallController ballController;
    public Camera cam;
    public float OriginalZoom = 5;
    public float TargetZoom = 20;
    public float Timer = 0;
    
    void Start()
    {
        OriginalZoom = 1;
        cam.orthographicSize = OriginalZoom;
        ballController = GetComponent<BallController>();
        

    }
    void Update()
    {
        _CameraZoomInOut();
    }

    private void _CameraZoomInOut()
    {

        if (ballController.PowerSlider.value >= 0.75)
        {
            cam.orthographicSize = TargetZoom;
            Timer = Time.time;
        }
        if (Timer >= 1)
        {
            cam.orthographicSize = OriginalZoom;
            Timer = 0;
        }
    }
}
