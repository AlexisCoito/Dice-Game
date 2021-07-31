using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;


    float horizontalInput;
    float verticalInput;
    [SerializeField] float mouseSensivity;
    protected float speed = 3f;
    public CharacterController controller;
    public float jumpHeight = 3f;
    public GameManager gameManager;

    public GameObject dado;
    Dado dadoS;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float gravity = -9.81f;

    protected Vector3 velocity;
    protected bool isGrounded;

    Quaternion randomQuat;
    public Vector3 rotate1;
    public Vector3 rotate2;

    public bool isPlayer1Turn;
    public bool isPlayer2Turn;

    public Animator animator;

    // Update is called once per frame
    public virtual void Update()
    {
        randomQuat = new Quaternion(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        rotate1 = player1.transform.position + (Camera.main.transform.forward)*1.5f;
        rotate2 = player2.transform.position + (Camera.main.transform.forward) * 1.5f;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        GetPlayerInput();
        MovePlayer();
        Jump();
        Throw();
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

       

        

    }

    public virtual void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public virtual void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

    public virtual void MovePlayer()
    {
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * speed * Time.deltaTime);
        
    }

    public virtual void InstanDado (Vector3 rota, GameObject player)
    {
        
            Instantiate(dado, player.transform.position + (Camera.main.transform.forward) * 1.5f, randomQuat);  
    }

    public virtual void Throw()
    {
        if (Input.GetKeyDown(KeyCode.X) && isPlayer1Turn)
        {
            InstanDado(rotate1, player1);
            gameManager.TurnEnded(); 
        }

        if (Input.GetKeyDown(KeyCode.M) && isPlayer2Turn)
        {
            InstanDado(rotate2, player2);
            gameManager.TurnEnded();
        }
    }
    
}