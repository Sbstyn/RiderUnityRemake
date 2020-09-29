using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 0f;
    public bool isgrounded = false;
    public float rot = 0;

    public Rigidbody2D rb;
    public Camera cam;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isgrounded == false)
        {
            rb.MoveRotation(Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + rot));
            rot = rot + 5;
        }

        if (Input.GetKey(KeyCode.Mouse0) && isgrounded == true)
        {
            if (speed < 10)
            {
                speed = speed + 0.1f;
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
            }
            else
            {
                speed = 10;
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
            }
        }

        if (isgrounded == false)
        {   
            if (speed > 0)
            {
                speed = speed - 0.1f;
            }
            transform.Translate(rb.velocity.normalized * Time.deltaTime * speed);
            //Vector3 oldDir = rb.velocity;
            //rb.velocity = Quaternion.Euler(0, 0, 90) * oldDir;
            //rb.AddForce(transform.forward * speed);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" && Input.GetKey(KeyCode.Mouse0))
        {
            rb.velocity = Vector3.zero;
        }
        if (col.gameObject.tag == "ground")
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" && Input.GetKey(KeyCode.Mouse0))
        {
            isgrounded = false;
        }
    }
}
