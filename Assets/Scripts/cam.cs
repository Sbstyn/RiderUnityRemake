using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject target;
     void Update()
     {
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y);
     }
}
