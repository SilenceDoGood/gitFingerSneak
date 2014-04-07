using UnityEngine;
using System.Collections;

public class guiController : MonoBehaviour
{
	public GUISkin menuStyle;

	private int boxH = Screen.height / 4;
	private int boxW = Screen.width / 4;
	private float screenM; 
	private Vector3 posA;
	private Vector3 posB;
    private static bool gameOver;

    void Awake()
    {
        gameOver = false; 
    }

	void Start()
    {
		screenM = boxH * 0.01f;
	}

	void OnGUI()
    {
        if(gameOver)
        {
            GUI.Box (new Rect (Screen.width*0.33f,Screen.height*0.33f,Screen.width*0.33f,Screen.height*0.2f), "GAME OVER!");
            if(GUI.Button (new Rect(Screen.width*0.33f + 200, Screen.height*0.33f + 200 , 100, 100), "Retry"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

		GUI.skin = menuStyle;
		GUI.Box (new Rect(screenM, screenM, boxW, boxH), "Variable Watcher");
		GUI.Label (new Rect(20, 40, boxW - 10, boxH / 4 - 5), "Touch Count: " + Input.touchCount);
        GUI.Label (new Rect(20, 70, boxW - 10, boxH / 4 - 5), "Player can Move: " + GameObject.Find ("_Game_Controller").GetComponent<GameController> ().GetCanMove);
		GUI.Label (new Rect(20, 100, boxW - 10, boxH / 4 - 5), "P-Position " + GameObject.Find ("Player").transform.position);
		GUI.Label (new Rect(20, 130, boxW - 10, boxH / 4 - 5), "rayDistance " + GameObject.Find ("_Game_Controller").GetComponent<GameController> ().SetGameOver);
        GUI.Label (new Rect(20, 160, boxW - 10, boxH / 4 - 5), "Distance between: " + GameObject.Find ("_Game_Controller").GetComponent<GameController> ().DistanceBetweenPoints);
		GUI.Label (new Rect(20, 190, boxW - 10, boxH / 4 - 5), "Touch 0: " + Input.GetTouch(0).phase);
		GUI.Label (new Rect(20, 220, boxW - 10, boxH / 4 - 5), "Touch 1: " + Input.GetTouch(1).phase);
	}

    public static void ChangeState(bool newValue)
    {
        gameOver = newValue;
    }
}
    