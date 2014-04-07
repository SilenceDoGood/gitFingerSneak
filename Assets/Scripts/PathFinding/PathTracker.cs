using UnityEngine;
using System.Collections;

public class PathTracker : MonoBehaviour 
{
    private Vector3 currentNode;
    private Transform targetNode;

    public float timeToObject;
    public Transform[] path;

    private float startTime;
    private float speed = 25.0f;
    private float journeyLength;
    private int nodeInx = 0;
    private float fracJourney;

	void Start () {
        trackToNextNode();
        animation.Play("walk");
	}

	void Update () 
    {
        float distCovered = (Time.time - startTime) * speed;
        fracJourney = Mathf.Clamp01(distCovered / journeyLength);
        transform.position = Vector3.Lerp(currentNode, targetNode.transform.position, fracJourney);

        if(fracJourney >= 1.0f)
        {
            //TO DO: process commands when target has been reached
            nodeInx++;
            if(nodeInx >= path.Length)
            {
                nodeInx = 0;
                trackToNextNode();
            } 
            else
            {
                trackToNextNode();
            }
        }
	}

    private void trackToNextNode()
    {
        startTime = Time.time;
        currentNode = transform.position;
        fracJourney = 0;

        targetNode = path[nodeInx];

        journeyLength = Vector3.Distance(currentNode, targetNode.position); 

        if(targetNode != null)
        {
            transform.LookAt(targetNode.transform.position, Vector3.up);
        }
    }
}