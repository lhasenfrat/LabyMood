using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name+ " "+ collider.gameObject.tag);
        if (collider.gameObject.tag == "player")
        {
            collider.gameObject.GetComponent<positionRecorder>().NormalEnd();
        }
    }
}
