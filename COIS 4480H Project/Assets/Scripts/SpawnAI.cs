using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour {
    private int maxAI;

	// Use this for initialization
	void Start () {
        GameObject instance;
        maxAI = 25;
        for (int i = 0; i < maxAI; i++)
            instance = Instantiate(Resources.Load("AI", typeof(GameObject))) as GameObject;


    }
}
