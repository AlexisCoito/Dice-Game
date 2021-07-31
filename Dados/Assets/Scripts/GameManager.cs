using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int dado1, dado2;
    public PlayerController playerController;
    public bool twoTurnsEnded;
    public TextMeshProUGUI result1;
    public TextMeshProUGUI result2;

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
            result1.gameObject.SetActive(false);
            result2.gameObject.SetActive(false);

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
            result1.gameObject.SetActive(true);
            result1.text = "Player1 Roll " + dado1.ToString();
            //Debug.Log("Dado Jugador 1 : " + dado1);
        }else{
            dado2 = valor;
            result2.gameObject.SetActive(true);
            result2.text = "Player2 Roll " + dado2.ToString();
            //Debug.Log("Dado Jugador 2 : " + dado2);
        }
    }
}
