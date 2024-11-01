using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player_Collider : MonoBehaviour
{

    void Update()
    {     
    }

    private void OnTriggerStay(Collider other) // objetos dentro do colisor do player_collider
    {
        // se objeto dentro do colisor for monstro e colisor estiver ativo
        if(other.gameObject.name == ("Monstro_azul(Clone)") && GameObject.Find("Player_Collisor").GetComponent<Player_Collider>().enabled == true )
        {
            print("if monstro tá no triggerstay do collider");
            other.gameObject.SetActive(false); // apaga monstro dentro do colisor
            GameObject.Find("Player_Collisor").GetComponent<Player_Collider>().enabled = false; // desativa o colisor
        }

    }
}