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
        if(_rightClick.IsPressed())
        {
            yaw += lookSpeedH * Mouse.current.delta.x.ReadValue();
            pitch -= lookSpeedV * Mouse.current.delta.y.ReadValue();

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        if (_middleClick.IsPressed()){
            var moveX = Mouse.current.delta.x.ReadValue();
            var moveY = Mouse.current.delta.y.ReadValue();
            transform.Translate(-moveX * Time.deltaTime * dragSpeed, -moveY * Time.deltaTime * dragSpeed, 0);
        }

        if (_scroll.ReadValue<Vector2>().magnitude >0 ){
            var norm = _scroll.ReadValue<Vector2>().normalized;
            transform.Translate(0, 0,  norm[1] * zoomSpeed, Space.Self);
        }
    }

    public void resetCameraPosition()
    {
        this.gameObject.transform.position = new Vector3(10,2,-10);
        this.gameObject.transform.rotation = new Quaternion(0,0,0,0);
    }
}
