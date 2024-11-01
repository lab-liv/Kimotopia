using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;


public class Inputs : MonoBehaviour
{


    //Send inputs values for server script

    public static string valor1;
    public static string valor2;
    public static string valor3;
    public static string valor4;
    public static string valor5;
    public static string valor6;
    public static string valor7;


	public void Start ()
	{
		
	}
    //Fase de Medicação
    public void ClickFaseM()
    {

        valor1 = GameObject.Find("tempo1input").GetComponent<InputField>().text;
        valor2 = GameObject.Find("inputQC").GetComponent<InputField>().text;
        valor3 = GameObject.Find("inputQE").GetComponent<InputField>().text;

		SceneManager.LoadScene("Modulo_FaseA");
        


    }

    //Fase de Alimentação
    public void ClickFaseA()
    {

        valor4 = GameObject.Find("tempo2input").GetComponent<InputField>().text;
        valor5 = GameObject.Find("inputQC2").GetComponent<InputField>().text;

		SceneManager.LoadScene("Modulo_FaseH");

    }

    //Fase de Higiene
    public void ClickFaseH()
    {
        valor6 = GameObject.Find("tempo3input").GetComponent<InputField>().text;
        valor7 = GameObject.Find("inputQC3").GetComponent<InputField>().text;

		SceneManager.LoadScene("Modulo_rede");

    }


    public void ClickIniciar()
	{
		 //nomejogador = GameObject.Find ("jogadorinput").GetComponent<InputField> ();
		 //idadejogador = GameObject.Find ("idadeinput").GetComponent<InputField> ();
		
	}

}
