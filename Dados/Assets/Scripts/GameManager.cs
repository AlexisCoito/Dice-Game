using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int dado1, dado2;
    public PlayerController playerController;
    public bool twoTurnsEnded;

    // Start is called once 
    void Start()
    {
        twoTurnsEnded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnEnded()
    {

        if (twoTurnsEnded)
        {
            playerController.isPlayer1Turn = false;
            playerController.isPlayer2Turn = false;
            Debug.Log("ahora no juegan");
            //Funcion de la IA
            twoTurnsEnded = false;
            playerController.isPlayer1Turn = true;
            Debug.Log("ahora si");

        }
        else if (playerController.isPlayer1Turn)
        {
            playerController.isPlayer1Turn = false;
            playerController.isPlayer2Turn = true;


        }
        else
        {
            playerController.isPlayer2Turn = false;
            twoTurnsEnded = true;
            TurnEnded();
        }

    }

    public void ValuesUpdate(int valor){
        if(!playerController.isPlayer1Turn){
            dado1 = valor;
            //Debug.Log("Dado Jugador 1 : " + dado1);
        }else{
            dado2 = valor;
            //Debug.Log("Dado Jugador 2 : " + dado2);
        }
    }
}
