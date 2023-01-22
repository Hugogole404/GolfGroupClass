using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;


public class BallController : MonoBehaviour
{
    // ball 
    [Header("Ball Setting")]
    [SerializeField] public float MaxPower;
    [SerializeField] public float ChangeAngleSpeed;

    // line ball 
    [Header("Ball Line Setting")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private Rigidbody ball;
    [SerializeField] private float angle;

    // ui power ball 
    [Header("UI Ball Power Setting")]
    [SerializeField] public float LineLenght;
    [SerializeField] public Slider PowerSlider;
    [SerializeField] private float powerUPTime;
    [SerializeField] private float power;

    // putt 
    [Header("Putts Setting")]
    [SerializeField] public TextMeshProUGUI puttsCountsLabel;
    [SerializeField] private int putts;

    // hole
    [Header("Hole Setting")]
    [SerializeField] public float minHoleTime;
    [SerializeField] private float holeTime;

    void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (ball.velocity.magnitude < 0.01f)
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
        else
        {
            line.enabled = false;
        }
    }

    private void ChangeAngle(int direction)
    {
        angle += ChangeAngleSpeed * Time.deltaTime * direction;
    }

    private void UpdateLinePosition()
    {
        if (holeTime == 0)
        {
            line.enabled = true;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * LineLenght);
    }

    private void Putt()
    {
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * MaxPower * power, ForceMode.Impulse);
        power = 0;
        PowerSlider.value = 0;
        powerUPTime = 0;
        putts++;
        puttsCountsLabel.text = putts.ToString();
    }

    private void PowerUp()
    {
        powerUPTime += Time.deltaTime;
        power = Mathf.PingPong(powerUPTime, 1);
        PowerSlider.value = power;
    }

    private void OnTriggerStay(Collider other)
    {
        if ( other.tag == "Hole")
        {
            CountHoleTime();
        }
    }    

    private void CountHoleTime()
    {
        holeTime += Time.deltaTime;
        if (holeTime > minHoleTime)
        {
            // le player fini le niveau et passe au suivant 
            Debug.Log("Vous avez passé ce niveau en " + putts + " tirs");
            holeTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.tag == "Hole")
        {
            LeftHole();
        }
    }

    private void LeftHole()
    {
        holeTime = 0;
    }
}
