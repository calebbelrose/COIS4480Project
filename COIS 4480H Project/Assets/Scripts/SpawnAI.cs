using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour {
    private int maxAI;

	// Use this for initialization
	void Start () {
        AI
        maxAI = 25;
        for (int i = 0; i < maxAI; i++)
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        
    }
}
