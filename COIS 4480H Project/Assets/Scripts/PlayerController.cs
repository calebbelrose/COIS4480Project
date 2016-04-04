using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    void Start()
    {
        Color[] colors = { Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow };
        Color currColor;
        Renderer[] renderers;

        transform.Translate(Random.value * 8f - 4f, 0.3047705f, Random.value * 8f - 4f);
        renderers = gameObject.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            currColor = colors[(int)(Random.value * colors.Length)];
            renderers[i].material.color = currColor;
        }
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