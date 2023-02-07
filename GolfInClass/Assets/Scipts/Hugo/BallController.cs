using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using DG.Tweening;


public class BallController : MonoBehaviour
{
    // start ball  
    [Header("Ball Position")]
    public Transform startTransform;

    // respawn ball 
    [Header("Resapawn Ball Settings")]
    private Vector3 lastPosition;

    // ball 
    [Header("Ball Setting")]
    [SerializeField] public float MaxPower;
    [SerializeField] private float ChangeAngleSpeed;

    // line ball 
    [Header("Ball Line Setting")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private Rigidbody ball;
    [SerializeField] private float angle;

    // ui power ball 
    [Header("UI Ball Power Setting")]
    [SerializeField] private float LineLenght;
    public Slider PowerSlider;
    [SerializeField] private float powerUPTime;
    [SerializeField] private float power;

    // putt 
    [Header("Putts Setting")]
    [SerializeField] private TextMeshProUGUI puttsCountsLabel;
    [SerializeField] private int putts;

    // hole
    [Header("Hole Setting")]
    [SerializeField] private float minHoleTime;
    [SerializeField] private float holeTime;

    // WindArea(Ventilos)
    [Header("Wind Area Settings")]
    [SerializeField] private bool InWindArea = false;
    public GameObject windArea;

    // BoosterArea(Boosters)
    [Header("Booster Area Setting")]
    [SerializeField] private bool InBoosterArea = false;
    public GameObject boosterArea;
    private float boosterTime;
    public float distancePowerModifier;

    // autre
    public LevelManager levelManager;


    void Awake()
    {
        //plane = new Plane(Vector3.up, 0);
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
        startTransform.GetComponent<MeshRenderer>().enabled = false;
    }

    //#region Rayon
    //private Plane plane;
    //private Ray mousePositionRay;
    //private Vector3 hitPoint = Vector3.zero;
    //private Vector3 playerPositionOnPlane = Vector3.zero;
    ////private 

    //private void OnMouseUp()
    //{
    //    //peut etre des trucs à faire quand on relache le click
    //}
    //private void OnMouseDrag()
    //{
    //    mousePositionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (plane.Raycast(mousePositionRay, out var enter))
    //    {
    //        hitPoint = mousePositionRay.GetPoint(enter);
    //        playerPositionOnPlane = plane.ClosestPointOnPlane(transform.position);
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Vector3 direction = hitPoint - playerPositionOnPlane;
    //    direction = direction.magnitude > MaxPower ? direction.normalized * MaxPower : direction;
    //    Gizmos.DrawLine(playerPositionOnPlane, playerPositionOnPlane + direction );

    //}
    //#endregion

    void Update()
    {

        if (ball.velocity.magnitude < 0.15f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ChangeAngle(-1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
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
        lastPosition = transform.position;
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
        if (other.tag == "Hole")
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
            if (putts <= 1)
            {
                Debug.Log("Vous avez passé ce niveau en " + putts + " tir");
            }
            else
            {
                Debug.Log("Vous avez passé ce niveau en " + putts + " tirs");
            }
            levelManager.NextPlayer(putts);
            holeTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hole")
        {
            LeftHole();
        }

        //Pour le vent : Quand la balle sors de la zone bool = false
        if (other.gameObject.tag == "windArea")
        {
            InWindArea = false;
        }

        //Pour le booster : Quand la balle sors de la zone bool = false
        if (other.gameObject.tag == "boosterArea")
        {
            InBoosterArea = false;
        }
    }

    private void LeftHole()
    {
        holeTime = 0;
    }

    //Pour le vent : Quand la balle entre dans la zone bool = true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "windArea")
        {
            windArea = other.gameObject;
            InWindArea = true;
        }

        //Pour le booster : Quand la balle entre dans la zone bool = true
        if (other.gameObject.tag == "boosterArea")
        {
            boosterArea = other.gameObject;
            InBoosterArea = true;
            ball.velocity = Vector3.zero;
            gameObject.transform.DOMove(other.transform.position, distancePowerModifier, false);
            //ball.AddForce(boosterArea.GetComponent<boosterArea>().Boosterdirection * boosterArea.GetComponent<boosterArea>().BoosterStrength);
            print("In booster area");
        }
    }


    private void FixedUpdate()
    {
        //Actions par rapport aux bools juste au dessus (ce qui fait que la balle bouge)
        //Wind :
        if (InWindArea)
        {
            ball.AddForce(windArea.GetComponent<windArea>().Airdirection * windArea.GetComponent<windArea>().AirStrength);
        }
        if (InBoosterArea)
        {
            boosterTime = Time.time;
            if (boosterTime >= distancePowerModifier)
            {
                ball.AddForce(boosterArea.GetComponent<boosterArea>().Boosterdirection * boosterArea.GetComponent<boosterArea>().BoosterStrength);
                boosterTime = 0;
            }
        }
        //Booster :
        //if (InBoosterArea)
        //{

        //    //GetComponent<Rigidbody>().velocity = Vector3.zero;
        //    //boosterTime = Time.time;
        //    boosterTime += Time.fixedDeltaTime;
        //}
        //if (boosterTime >= 1)
        //{
        //    ball.AddForce(boosterArea.GetComponent<boosterArea>().Boosterdirection * boosterArea.GetComponent<boosterArea>().BoosterStrength);
        //    boosterTime = 0;
        //}
        //if (boosterTime >= 2)
        //{
        //    boosterTime = 0;
        //    InBoosterArea = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "OutOfBounds")
        {
            transform.position = lastPosition;
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
        }
    }

    public void SetupBall(Color color)
    {
        transform.position = startTransform.position;
        angle = startTransform.rotation.eulerAngles.y;
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        line.material.SetColor("_Color", color);
        line.enabled = true;
        putts = 0;
        puttsCountsLabel.text = "0";
    }
}
