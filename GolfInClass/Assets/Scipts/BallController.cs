using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float MaxPower;
    public float ChangeAngleSpeed;

    private LineRenderer line;
    [SerializeField] private Rigidbody ball;
    private float angle;
    public float LineLenght;

    public Slider PowerSlider;
    private float powerUPTime;
    private float power;

    void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ChangeAngle(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ChangeAngle(1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Putt();
        }         
        if (Input.GetKey(KeyCode.Space))
        {
            PowerUp();
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

    private void Putt()
    {
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * MaxPower * power, ForceMode.Impulse);
        power = 0;
        PowerSlider.value = 0;
        powerUPTime = 0;
    }

    private void PowerUp()
    {
        powerUPTime += Time.deltaTime;
        power = Mathf.PingPong(powerUPTime, 1);
        PowerSlider.value = power;
    }
}
