using UnityEngine;
using System.Collections;

public class bonusReward : MonoBehaviour {

    private int currLocation;
    void Start()
    {
        currLocation = (int)(Random.value * Timer.targets.Length - 1);
        gameObject.transform.position = Timer.targets[currLocation].transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision");
        if (collider.gameObject == Timer.player)
        {
            int newLocation;
            Timer.score++;
            do
            {
                newLocation = (int)(Random.value * Timer.targets.Length - 1);
            }while (newLocation == currLocation);

            currLocation = newLocation;
            gameObject.transform.position = Timer.targets[currLocation].transform.position;
        }
    }
}
