using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecords : MonoBehaviour
{
    public List<Player> playerList;
    public string[] levels;
    public Color[] playerColours;

    private void OnEnable()
    {
        playerList = new List<Player>();
        DontDestroyOnLoad(gameObject);
    }

    public void AddPlayer(string name)
    { 
        playerList.Add(new Player(name, playerColours[playerList.Count], levels.Length));
    }


    public class Player
    {
        public string name;
        public Color colour;
        int[] putts;

        public Player(string newName, Color newColor, int levelCount)
        {
            name = newName;
            colour = newColor;
            putts = new int[levelCount];
        }
    }
}
