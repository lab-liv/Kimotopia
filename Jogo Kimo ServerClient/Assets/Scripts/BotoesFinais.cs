using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesFinais : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Voltar()
	{

		SceneManager.LoadScene ("Modulo_espera_desktop");
	}
	public void Sair()
	{
		Application.Quit ();
	}
	public void Voltar2()
	{

		SceneManager.LoadScene ("Modulo_espera_acelerometro");
	}
}
