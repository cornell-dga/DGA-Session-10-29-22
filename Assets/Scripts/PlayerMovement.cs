using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pushForce;
    public float jumpForce;
    public Transform cam;

    
    Vector3 Flatten(Vector3 n) {
        n.y = 0;
        return n.normalized;
    }

    bool GroundCheck() {
        RaycastHit hit;
        // ignore player
        int layerMask = 1 << 3;
        layerMask = ~layerMask;
        return Physics.Raycast(transform.position + Vector3.down*0.48f, Vector3.down, out hit, 0.1f, layerMask);
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 push = new Vector3();
        float v = Input.GetAxis("Vertical")*pushForce;
        float h = Input.GetAxis("Horizontal")*pushForce;
        push += Flatten(cam.right)*h;
        push += Flatten(cam.forward)*v;
        rb.AddForce(push*Time.deltaTime, ForceMode.Force);
        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck()) {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }
}
