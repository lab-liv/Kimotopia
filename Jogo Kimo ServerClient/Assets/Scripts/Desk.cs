using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
   

    public static GameObject modulo_game;
    public static GameObject modulo_espera;
    public static GameObject modulo_aplicador;

    public void Start()
    {

    }


    //Iniciar
    public void TaskOnClickIniciar()
    {
        AtivaGameDesktop.modulo_game.SetActive(true);
        modulo_espera = GameObject.Find("Espera");
        modulo_espera.SetActive(false);

    }

    //Finalizar
    public void TaskOnClickFinalizar()
    {
        Debug.Log("asuasusuhusauhsahusahusahusahusauhsahushshshushusuhsahusauhsahusahusauhsahsahushsasua");
        //SceneManager.LoadScene("Modulo_fim");

        //modulo_aplicador.SetActive (true);

    }



    //Update da velocidade do Kim
    public void Update()
    {

    }
}
