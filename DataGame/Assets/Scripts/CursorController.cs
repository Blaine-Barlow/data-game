using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    private InputController controls;
    private Camera mainCamera;

    private void Awake() {
        controls = new InputController();
        mainCamera = Camera.main;
    }

    private void Start() {
        controls.Main.MouseLeftClick.started += _ => startedClick();
        controls.Main.MouseLeftClick.performed += _ => endedClick();
    }

    private void OnEnable() {
        controls.Enable();    
    }

    private void OnDisable() {
        controls.Disable();
    }

    private void startedClick()
    {
        detectObject();
    }

    private void endedClick()
    {

    }


    private void detectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Main.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.tag);
            }
        }
    }
}
