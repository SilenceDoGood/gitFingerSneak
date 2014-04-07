using UnityEngine;
using System.Collections;

public class SoundWave : MonoBehaviour
{
	private float distance;
	public float swMultiplier;

    public void Initialize (float newDistance)
    {
        distance = (newDistance * swMultiplier) * (newDistance * swMultiplier);
    }

	void Update () 
    {
		if (transform.lossyScale.magnitude < new Vector3(distance, 1, distance).magnitude) 
        {
			transform.localScale += new Vector3 (20, 0, 20);
		} 
        else 
        {
			Destroy(gameObject);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Guard")
        {
            GameObject.Find ("_Game_Controller").GetComponent<GameController>().SetGameOver = true;
            guiController.ChangeState(true);
        }
    }
}
