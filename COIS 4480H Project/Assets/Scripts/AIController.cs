using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    private GameObject[] targets;
    public Transform goal;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        transform.Translate(Random.value * 8f - 4f, 0.33f, Random.value * 8f - 4f);
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        targets = GameObject.FindGameObjectsWithTag("NavMeshTarget");
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        GUI.Label(new Rect(Screen.width / 2 - 50, 300, 100, 100), gameObject.GetComponent<Renderer>().material.color.ToString(), myStyle);
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (targets.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = targets[destPoint].transform.position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % targets.Length;
    }

    // Update is called once per frame
    void Update ()
    {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
