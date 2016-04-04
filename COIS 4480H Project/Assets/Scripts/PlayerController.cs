using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    void Start()
    {
        transform.Translate(Random.value * 8f - 4f, 0.33f, Random.value * 8f - 4f);
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime * 100;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    void FixedUpdate ()
    {

    }
}
