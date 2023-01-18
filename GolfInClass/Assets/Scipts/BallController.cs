using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float MaxPower;
    public float ChangeAngleSpeed;

    private LineRenderer line;
    [SerializeField] private Rigidbody ball;
    private float angle;
    public float LineLenght;

    void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ChangeAngle(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ChangeAngle(1);
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        UpdateLinePosition();
    }

    private void ChangeAngle(int direction)
    {
        angle += ChangeAngleSpeed * Time.deltaTime * direction;
    }

    private void UpdateLinePosition()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * LineLenght);
    }
}
