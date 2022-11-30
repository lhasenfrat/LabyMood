using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public GameObject origin;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            Vector3 newpos = collision.GetContact(0).normal * 0.1f;
            newpos.y = 0;
            origin.transform.position+=newpos;

        }
    }
}
