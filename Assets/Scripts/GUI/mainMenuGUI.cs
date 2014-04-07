using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour {
	public GUISkin menuStyle;

	public Texture2D icon;

	void OnGUI (){
		GUI.Box (new Rect (Screen.width*0.33f,Screen.height*0.33f,Screen.width*0.33f,Screen.height*0.2f), icon);
	}
}
