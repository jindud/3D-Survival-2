using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    public float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rd = collision.collider.GetComponent<Rigidbody>();

        if(rd != null)
        {
            rd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
