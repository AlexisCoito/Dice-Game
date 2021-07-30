using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dado : MonoBehaviour
{
    private Rigidbody dadoRb;
    private GameObject player;
    [SerializeField] float speed = 15f;
    bool collisioned;
    Vector3 rotationDirection;
    // Start is called before the first frame update
    void Start()
    {
        collisioned = false;
        dadoRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        dadoRb.AddForce(Vector3.up * Time.deltaTime * speed *2);
        dadoRb.AddForce(player.transform.forward * Time.deltaTime * speed);
        rotationDirection = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        StartCoroutine("DestroyDices");
    }

    // Update is called once per frame
    void Update()
    {
        if (!collisioned)
        {
            dadoRb.AddTorque(rotationDirection * Time.deltaTime * speed * 10000, ForceMode.Force);
        }
    }

    IEnumerator DestroyDices()
    {   
        yield return new WaitForSeconds (5);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisioned = true;
    }
}
