using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour {

	public GUISkin mySkin;
	private bool toggle = false;
	private int boxH = Screen.height / 4;
	private int boxW = Screen.width / 4;
	

	void OnGUI () {
		// Assign the skin to be the one currently used.
		GUI.skin = mySkin;

		if(Application.loadedLevel == 0){
			GUI.Box(new Rect(10, 10, boxW, boxH), "Variable Watcher");
			GUI.Label (new Rect (20, 40, boxW - 5, boxH - 5), "Device Width " + Screen.width);
			GUI.Label (new Rect (20, 70, boxW - 5, boxH - 5), "Device Height " + Screen.height);
			GUI.Label (new Rect (20, 100, boxW - 5, boxH - 5), "Ten Percent " + Screen.width * 0.1f);
		}

		toggle = GUI.Toggle (new Rect (Screen.width - 110,10,100, 100), toggle, "Level Loader", "button");

		if(toggle){
			GUI.Box(new Rect(Screen.width - (boxW + 10), 150, boxW, boxH), "Level Loader");
			if(Application.loadedLevel == 0){
				if(GUI.Button(new Rect(Screen.width - (boxW+5), 190, boxW-10, 100), "movementTest")){
					Application.LoadLevel("TestLevel");
				}
			} else {
				if(GUI.Button(new Rect(Screen.width - (boxW+5), 190, boxW-10, 100), "mainMenu")){
					Application.LoadLevel("mainMenu");
				}
			}
		}
	}
}
