using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;

    MeshRenderer _render;

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        _input.Player.RandomiseColor.performed += RandomiseColor_performed;

        _render = GetComponent<MeshRenderer>();
    }

    private void RandomiseColor_performed(InputAction.CallbackContext context)
    {
        _render.material.color = Random.ColorHSV();
    }

    private void Rotate()
    {
        var direction = _input.Player.Rotate.ReadValue<float>();
        transform.Rotate(Vector3.up * (direction / 2));
    }

    private void DrivingMovement()
    {
        var direction = _input.Driving.Movement.ReadValue<Vector2>();
        transform.Translate(new Vector3(direction.x, 0f, direction.y) * 3 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        DrivingMovement();

        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchInputMap();
        }
    }

    private void SwitchInputMap()
    {
        if (_input.Player.enabled == true)
        {
            _input.Driving.Enable();
            _input.Player.Disable();
        }
        else
        {
            _input.Player.Enable();
            _input.Driving.Disable();
        }
    }
}
