using UnityEngine;
using System.Collections;

public class VisionScript : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            GameObject.Find ("_Game_Controller").GetComponent<GameController>().SetGameOver = true;
            guiController.ChangeState(true);
        }
    }
}
    