using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    private SphereInputActions _input;

    [SerializeField] private float _jumpForce;
    [SerializeField] private Slider _jumpMeter;

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _input = new SphereInputActions();
        _input.Sphere.Enable();
        _input.Sphere.Jump.canceled += Jump_canceled;

        _rb = GetComponent<Rigidbody>();
    }

    private void Jump_canceled(InputAction.CallbackContext context)
    {
        float forceOnHold = (float)context.duration;
        forceOnHold = Mathf.Clamp(forceOnHold, 0.5f, 1.0f);
        _rb.AddForce(Vector3.up * (_jumpForce * forceOnHold), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        ChargeMeter();
    }

    private void ChargeMeter()
    {
        if (_input.Sphere.Jump.IsPressed())
        {
            _jumpMeter.value += Time.deltaTime;
        }
        else if (_jumpMeter.value > 0f)
        {
            _jumpMeter.value -= 0.02f;
        }
    }
}
