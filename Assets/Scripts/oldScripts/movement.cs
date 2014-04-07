using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public GameObject footPrint;
	public GameObject player;
	public GameObject soundWave;

	public bool Touch1 = false;

	public float distance;

	private Quaternion footRot = new Quaternion(90, 0, 0, 90);
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 0) {
			Touch1 = false;
		}

		if(Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began){
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
			RaycastHit hit = new RaycastHit();
			Physics.Raycast (ray, out hit);
			
			if(hit.collider.gameObject.name == "Player"){
				Touch1 = true;
			}
		} 

		if (Input.GetTouch(0).phase == TouchPhase.Began) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
			RaycastHit hit = new RaycastHit();
			Physics.Raycast (ray, out hit);
			
			if(hit.collider.gameObject.name == "TileFloor"){
				distance = hit.distance;
			}

			var fingerPos = Input.GetTouch(0).position;
			Vector3 newPos = fingerPos;
			newPos.z = distance;
			var worldPosition = Camera.main.ScreenToWorldPoint(newPos);

			if(Touch1 && Input.touchCount == 2){
				player.transform.position = worldPosition;
				Instantiate(footPrint, worldPosition, footRot);
				Instantiate(soundWave, worldPosition, Quaternion.identity);
			}
		}

		if (Input.GetTouch (1).phase == TouchPhase.Began) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
			RaycastHit hit = new RaycastHit();
			Physics.Raycast (ray, out hit);
			
			if(hit.collider.gameObject.name == "TileFloor"){
				distance = hit.distance;
			}

			var fingerPos = Input.GetTouch(1).position;
			Vector3 newPos = fingerPos;
			newPos.z = distance;
			var worldPosition = Camera.main.ScreenToWorldPoint(newPos);

			if(Touch1 && Input.touchCount == 2){
				player.transform.position = worldPosition;
				Instantiate(footPrint, worldPosition, footRot);
				Instantiate(soundWave, worldPosition, Quaternion.identity);
			}
		}
	}
}
