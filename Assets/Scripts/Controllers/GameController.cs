using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

    private GameObject PlayerController;
    private bool canMove = false;
    private string playerName = "Player";
    private string floorName = "Tile_Floor";
    private float distance = 0;
    private float distanceToObject;
    private static bool gameOver = false;

    void Awake()
    {
        gameOver = false; 
    }

    void Start ()
    {
        PlayerController = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update () 
    {
        if(gameOver == false)
        {
            var lastPosition = PlayerController.transform.position;
            
            if (Input.touchCount == 0) 
            {
                canMove = false; 
            } 
            else if(InputCon.TouchedObject(playerName, Input.GetTouch (0)) || InputCon.TouchedObject(playerName, Input.GetTouch (1)))
            {
                canMove = true;
            } 
            
            if(InputCon.BeingTouched() && canMove)
            {
                if(Input.GetTouch (0).phase == TouchPhase.Began && InputCon.TouchedObject (floorName, Input.GetTouch (0)))
                {
                    var newPos = InputCon.CalcWorldPosition (Input.GetTouch (0), distanceToObject = InputCon.GetDistanceToObject(floorName, Input.GetTouch (0)));
                    PlayerController.GetComponent<PlayerController>().PlayerTransform = newPos;
                    distance = Vector3.Distance(newPos, lastPosition);
                    ObjectFactory.CreateSoundWave(newPos, distance);
                }
                
                if(Input.GetTouch (1).phase == TouchPhase.Began && InputCon.TouchedObject (floorName, Input.GetTouch (1)))
                {
                    var newPos = InputCon.CalcWorldPosition (Input.GetTouch (1), distanceToObject = InputCon.GetDistanceToObject(floorName, Input.GetTouch (1)));
                    PlayerController.GetComponent<PlayerController>().PlayerTransform = newPos;
                    distance = Vector3.Distance(newPos, lastPosition);
                    ObjectFactory.CreateSoundWave(newPos, distance);
                }
            }
        }
    }

    //GET-SET METHODs
    public bool GetCanMove
    {
        get
        {
            return canMove;
        }
    }
    
    public float RayDistance
    {
        get
        {
            return distanceToObject; 
        }
    }
    
    public float DistanceBetweenPoints
    {
        get
        {
            return distance; 
        }
    }

    public bool SetGameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            gameOver = value;
        }
    }
}