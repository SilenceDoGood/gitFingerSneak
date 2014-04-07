using UnityEngine;
using System.Collections;

public class ObjectFactory : MonoBehaviour 
{
    protected static ObjectFactory instance; 

    public GameObject soundWavePrefab;

	// Use this for initialization
	void Start () {
        instance = this;
	}

    public static GameObject CreateSoundWave (Vector3 position, float distance)
    {
        var cloneWave = (GameObject) Instantiate(instance.soundWavePrefab, position, Quaternion.identity);
        cloneWave.GetComponent<SoundWave>().Initialize(distance);
        return cloneWave;   
    }
}
