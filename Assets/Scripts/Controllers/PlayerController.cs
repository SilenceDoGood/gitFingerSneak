using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Vector3 startingPos = new Vector3(0, 0, 0); 

	private Vector3 playerPos;

	void Start ()
    {
		playerPos = startingPos;
	}

	// Update is called once per frame
	void Update ()
    {
        transform.position = playerPos;
	}

	public Vector3 PlayerTransform 
    {
		get
        {
			return playerPos;
		}

		set
        {
			playerPos = value;
		}
	}
}
