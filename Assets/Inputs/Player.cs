using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputActions _input;

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var movememnt = _input.Player.Movement.ReadValue<Vector2>();
        transform.Translate(new Vector3(movememnt.x, 0, movememnt.y) * Time.deltaTime * 3);
    }
}
