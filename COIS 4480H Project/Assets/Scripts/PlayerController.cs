using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        CharacterController controller = GetComponent<CharacterController>();
        float rotation;

        moveDirection = new Vector3(0, -9.81f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= 40 * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
        rotation = Input.GetAxis("Horizontal");
        rotation *= Time.deltaTime * 100;
        transform.Rotate(0, rotation, 0);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.collider.gameObject.ToString());
    }
}