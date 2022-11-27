using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementManager : MonoBehaviour
{
    public GameObject leftHand;
    void Start()
    {
        ChangeMovement();
    }

    public void ChangeMovement()
    {
        string movementtype = PlayerPrefs.GetString("Movement");
        if (movementtype == "Continuous")
        {
            GetComponent<ContinuousMoveProviderBase>().enabled = true;
            GetComponent<TeleportationManager>().enabled = false;
            leftHand.GetComponent<XRInteractorLineVisual>().enabled = false;

        }
        else
        {
            GetComponent<ContinuousMoveProviderBase>().enabled = false;
            GetComponent<TeleportationManager>().enabled = true;
            leftHand.GetComponent<XRInteractorLineVisual>().enabled = true;

        }
    }
}
