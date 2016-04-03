﻿using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public Transform[] points;
    public float moveSpeed;
    public Transform goal;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        transform.Translate(Random.value * 8f - 4f, 0.29f, Random.value * 8f - 4f);
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update ()
    {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
