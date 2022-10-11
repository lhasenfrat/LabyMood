using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor interactor;
    [SerializeField] private TeleportationProvider provider;

    private InputAction _thumbstick;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();
    }
    private void Update()
    {
        if (!_isActive)
        {
            return;
        }
        if (_thumbstick.triggered)
        {
            return;
        }
        if(!interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            interactor.enabled = false;
            _isActive = false;
            return;
        }
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition=hit.point
        };
        provider.QueueTeleportRequest(request);
        interactor.enabled = false;
        _isActive = false;
    }
    private void OnTeleportActivate(InputAction.CallbackContext callbackContext)
    {
        interactor.enabled = true;
        _isActive = true;
    }
    private void OnTeleportCancel(InputAction.CallbackContext callbackContext)
    {
        interactor.enabled = false;
        _isActive = false;
    }
}
