using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerController
{
    float up;
    float down;
    float right;
    float left;
    void Start()
    {
        isPlayer1Turn = true;
    }

    public override void GetPlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            up = 1;
        } else { up = 0; }
        if (Input.GetKey(KeyCode.S))
        {
            down = -1;
        }
        else { down = 0; }
        if (Input.GetKey(KeyCode.D))
        {
            right = 1;
        }
        else { right = 0; }
        if (Input.GetKey(KeyCode.A))
        {
            left = -1;
        }
        else { left = 0; }
    }

    public override void MovePlayer()
    {
        Vector3 move = transform.right * (right + left) + transform.forward * (up + down);
        controller.Move(move * speed * Time.deltaTime);
    }

    public override void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
