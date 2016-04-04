


using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

    private GameObject[] targets;
    public Transform goal;
    private int destPoint;
    private NavMeshAgent agent;
    private bool isMoving = true;

    // Use this for initialization
    void Start()
    {
        Material[] objMaterials;
        transform.Translate(Random.value * 8f - 4f, 0.33f, Random.value * 8f - 4f);
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        targets = GameObject.FindGameObjectsWithTag("NavMeshTarget");
        destPoint = (int)(Random.value * targets.Length);
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (targets.Length == 0)
            return;

        if (agent.enabled)
        {
            agent.Resume();
            isMoving = true;

            // Set the agent to go to the currently selected destination.
            agent.destination = targets[destPoint].transform.position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (int)(Random.value * targets.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && agent.remainingDistance < 0.5f)
        {
            if (isMoving)
            {
                agent.Stop();
                isMoving = false;
                Invoke("GotoNextPoint", Random.value + 0.5f);
            }
        }
    }
}
