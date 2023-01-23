using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedbacks : MonoBehaviour
{
    private Camera cam;
    public float ActualSize;
    public GameObject ball;
    private Vector3 offset;
    public float StartingSize;
    void Start()
    {
        cam = Camera.main;
        ActualSize = cam.orthographicSize;
        StartingSize = cam.orthographicSize;
        offset = transform.position - ball.transform.position;

    }
    
    
    void Update()
    {
        Debug.Log(ActualSize);

    }

    private void LateUpdate()
    {
        CameraFollowBall();
    }

    public void CameraFollowBall() //ici pour que la cam suit la balle
    {
        transform.position = ball.transform.position + offset;
    }

    private void ZoomCamera()
    {

    }
}
