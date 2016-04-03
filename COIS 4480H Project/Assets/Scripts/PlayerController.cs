using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    public float moveSpeed;

    void Start()
    {
        moveSpeed = 1f;
    }

    void Update()
    {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        /* CharacterController controller = GetComponent<CharacterController>();
        if (Input.GetButtonDown("W"))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(forward * curSpeed);
        }

        if (Input.GetButtonDown("S"))
        {
            Vector3 backward = transform.TransformDirection(-Vector3.forward);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(backward * curSpeed);
        }

        if (Input.GetButtonDown("A"))
        {
            Vector3 left = transform.TransformDirection(Vector3.left);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(left * curSpeed);
        }

        if (Input.GetButtonDown("D"))
        {
            Vector3 right = transform.TransformDirection(-Vector3.left);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(right * curSpeed);
        }*/
    }

    void FixedUpdate ()
    {

    }
}
