using UnityEngine;
using System.Collections;

public class bonusReward : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Timer.player)
        {
            Destroy(gameObject);
            Timer.score++;
        }
    }
}
