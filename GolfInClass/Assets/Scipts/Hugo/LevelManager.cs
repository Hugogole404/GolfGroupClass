using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BallController ball;

    private PlayerRecords playerRecords;
    private void Start()
    {
        playerRecords = GameObject.Find("Player Record").GetComponent<PlayerRecords>();
    }

    private void SetupPlayer()
    {
        
    }
}
