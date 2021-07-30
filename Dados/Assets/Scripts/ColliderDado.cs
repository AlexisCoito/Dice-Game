using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDado : MonoBehaviour
{
    public float asd=100;
    private Rigidbody mirb;
    private GameObject objVacio;
    public bool cualqueircosa = false;
    public RaycastHit hit;
    int caraActual = 0;
    nodoCara[] nodo = new nodoCara[6];
    public struct nodoCara
    {
        public int valor;
        public string nombre;
    }
    
    void Start()
    {
        objVacio = GameObject.Find("Lector");
        mirb = GetComponent<Rigidbody>();
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                nodo[i].valor = 6;
                nodo[i].nombre = "Cara" + 6;
            } else
            {
                nodo[i].valor = i;
                nodo[i].nombre = "Cara" + i;
            }
           
        }

      //  mirb.AddTorque(transform.up*Random.Range(50,100));
     //   mirb.AddTorque(transform.right*Random.Range(50,100));
    }
    
    void Update()
    {
        DiceThrow();
    }

    void DiceThrow()
    {
        objVacio.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        //Todo este if va dentro de la funcion Tirar Dado
        if (!cualqueircosa && (mirb.IsSleeping()))
        {

            if (Physics.Raycast(objVacio.transform.position, Vector3.down, out hit, 50))
            {
                cualqueircosa = true;
                int i = 0;
                while (i < 6 && caraActual == 0)
                {
                    if (hit.collider.name == nodo[i].nombre)
                    {
                        caraActual = nodo[i].valor;
                        //una vez que ya usemos caraActual tiene que ser 0 denuevo
                        Debug.Log(caraActual);

                    }
                    i++;
                }
            }
        }
    }

}

