using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer2 : MonoBehaviour
{
    float mouseXP;
    float mouseYP;
    float mouseXN;
    float mouseYN;

    public float mouseSensivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Keypad6))
        {
            mouseXP = 1 * mouseSensivity * Time.deltaTime;
        } else { mouseXP = 0; }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            mouseYP = 1 * mouseSensivity * Time.deltaTime;
        }
        else { mouseYP = 0; }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            mouseXN = -1 * mouseSensivity * Time.deltaTime;
        }
        else { mouseXN = 0; }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            mouseYN = -1 * mouseSensivity * Time.deltaTime;
        }
        else { mouseYN = 0; }


        xRotation -= mouseYP + mouseYN;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * (mouseXP + mouseXN));
    }
}
