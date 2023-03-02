using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody myRigidbody;

    void Awake ()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Movement (Vector3 direction, float velocity)
    {
        myRigidbody.MovePosition(
                myRigidbody.position +
                direction.normalized * velocity * Time.deltaTime);
    }

    public void Rotate (Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(direction);
            myRigidbody.MoveRotation(newRotation);
        }
    }

    public void Death()
    {
        myRigidbody.constraints = RigidbodyConstraints.None;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;
    }
}
