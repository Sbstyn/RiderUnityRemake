using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 0;
    public bool isgrounded = false;
    public float rot = 0;

    public Rigidbody2D rb;
    public Camera cam;

    void Update()
    {
        Debug.Log(isgrounded);

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

        if (Input.GetKey(KeyCode.Mouse0) && isgrounded == false)
        {
            if (speed > 0)
            speed = speed - 0.1f;
            transform.Translate(rb.velocity.normalized * Time.deltaTime * speed);
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