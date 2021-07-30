using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    [SerializeField] float mouseSensivity;
    [SerializeField] float speed = 12f;
    public CharacterController controller;
    public float jumpHeight = 3f;

    public GameObject dado;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded;

    Quaternion randomQuat;

    public bool isPlayerTurn;

    // Update is called once per frame
    void Update()
    {
        randomQuat = new Quaternion(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        Vector3 rotate = transform.position + (Camera.main.transform.forward)*1.5f;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        GetPlayerInput();
        MovePlayer();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InstanDado(rotate);
        }

    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * speed * Time.deltaTime);
    }

    void InstanDado (Vector3 rota)
    {
        Instantiate(dado, rota, randomQuat);
    }

    public void TurnEnded()
    {
        isPlayerTurn = !isPlayerTurn;
    }
}