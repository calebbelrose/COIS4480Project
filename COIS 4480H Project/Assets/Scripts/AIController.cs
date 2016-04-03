using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public Vector3 startPosition;
    public int roamRadius = 1;
    public float moveSpeed;
    // Use this for initialization
    void Start ()
    {
        moveSpeed = 1f;
        startPosition = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += startPosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector3 finalPosition = hit.position;
        //_nav.destination = finalPosition;
    }
}
