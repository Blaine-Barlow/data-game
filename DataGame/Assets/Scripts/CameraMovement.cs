using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraMovement : MonoBehaviour
{
    public float lookSpeedH = 2f;
    public float lookSpeedV = 2f;
    public float zoomSpeed = 2f;
    public float dragSpeed = 6f;

    private float yaw = 0f;
    private float pitch = 0f;

    private PlayerInput _PI;
    private InputAction _leftClick;
    private InputAction _rightClick;
    private InputAction _middleClick;
    private InputAction _scroll;

    void Awake()
    {
        _PI = GetComponent<PlayerInput>();
        _leftClick = _PI.actions["MouseLeftClick"];
        _rightClick = _PI.actions["MouseRightClick"];
        _middleClick = _PI.actions["MouseMiddleClick"];
        _scroll = _PI.actions["MouseScroll"];
    }
    void Update()
    {
        
        
        if(_leftClick.triggered)
        {
            Debug.Log("Left Click ");
        }


        if(_rightClick.triggered)
        {
            Debug.Log("Right Click ");
        }

        if (_middleClick.triggered){
            Debug.Log("Middle Click");
        }

        if (_scroll.ReadValue<Vector2>().magnitude >0 ){
            Debug.Log("Scroll wheel:  " + _scroll.ReadValue<Vector2>());
        }


    //     //Look around with Right Mouse
    //     if (Input.GetMouseButton(1))
    //     {
    //         yaw += lookSpeedH * Input.GetAxis("Mouse X");
    //         pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

    //         transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    //     }

    //     //drag camera around with Middle Mouse
    //     if (Input.GetMouseButton(2))
    //     {
    //         transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
    //     }

    //     //Zoom in and out with Mouse Wheel
    //     transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
    }
}
