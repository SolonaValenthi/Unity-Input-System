using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _input;

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Dog.Enable();
        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Walk.performed += Walk_performed;
        _input.Dog.Run.performed += Run_performed;
        _input.Dog.Die.performed += Die_performed;
    }

    private void Die_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private void Run_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Bark");
    }
}
