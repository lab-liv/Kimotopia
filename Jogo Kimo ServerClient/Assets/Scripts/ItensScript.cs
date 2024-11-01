using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItensScript : MonoBehaviour {

	// colisao de objeto com o player
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
        {

            // fase da medicacao--------------------------

                //caso colisao seja com o remedio
                if (gameObject.name == "pill(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeRemedioSound(); // metodo do som
                    gameObject.SetActive(false); //apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameController.Instance.TestarSeMaisVida(1); //testa se somou 10 para aumentar um coracao
                }
                else
                {
                    SoundScript.Instance.MakeRemedioSound(); // metodo do som
                    gameObject.SetActive(false); //apaga objeto colidido
                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(1); //testa se somou 10 para aumentar um coracao

                }


            }

                // caso colisao seja com o monstrinho
                else if (gameObject.name == "Monstro_azul(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                    {
                    SoundScript.Instance.MakeMonstroSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                    }
                    else
                    {
                    SoundScript.Instance.MakeMonstroSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0; //zera soma que aumentaria um coracao
                }






            }
            // fim medicacao----------------------------

            // fase alimentacao-----------------------------

                // caso colisao seja com a grape
                else if (gameObject.name == "grape(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeAppleSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameController.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                }
                else
                {
                    SoundScript.Instance.MakeAppleSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                }




            }

                // caso colisao seja com a melancia
                else if (gameObject.name == "watermelon(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeBananaSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameController.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao 
                }
                else
                {
                    SoundScript.Instance.MakeBananaSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                }
          


                }


                // caso colisao seja com a pumpkin
                else if (gameObject.name == "Pumpkin(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakePumpkinSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                                               //GameController.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                    GameController.Instance.TestarSeMaisVida(2);
                }
                else
                {
                    SoundScript.Instance.MakePumpkinSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                                                      //GameController.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(2);
                }


            }


                // caso colisao seja com a apple
                else if (gameObject.name == "Apple(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeCarrotSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameController.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                }
                else
                {
                    SoundScript.Instance.MakeCarrotSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(2); //testa se somou 10 para aumentar um coracao
                }
           


                }

                // caso colisao seja com o hamburger
               else if (gameObject.name == "Hambuger(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeHamburgerSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                }
                else
                {
                    SoundScript.Instance.MakeHamburgerSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0; //zera soma que aumentaria um coracao
                }
             



                }

                // caso colisao seja com o cake
                else if (gameObject.name == "Cake(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeCakeSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                }
                else
                {
                    SoundScript.Instance.MakeCakeSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0; //zera soma que aumentaria um coracao
                }
             



                }

                // caso colisao seja com as french fries
                else if (gameObject.name == "FrenchFries(Clone)")
                {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeCandySound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                }
                else
                {
                    SoundScript.Instance.MakeCandySound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0; //zera soma que aumentaria um coracao
                }
        



                }

            // caso colisao seja com o Icecream
            else if (gameObject.name == "Icecream(Clone)")
            {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeIcecreamSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                }
                else
                {
                    SoundScript.Instance.MakeIcecreamSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0;
                }
            



            }

             // fim alimentacao-------------------------------   

            // fase higiene -----------------------------

            // caso colisao seja com a higiene
            else if (gameObject.name == "Balde(Clone)")
            {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeHigieneSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.pontuacao++; //soma 1 na pontuacao da tela
                    GameController.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameController.Instance.TestarSeMaisVida(3); //testa se somou 10 para aumentar um coracao
                }
                else
                {
                    SoundScript.Instance.MakeHigieneSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.pontuacao++; //soma 1 na pontuacao da tela
                    GameControllerDesktop.maisVida++; //soma 1 para se somar 10 aumentar 1 coracao
                    GameControllerDesktop.Instance.TestarSeMaisVida(3); //testa se somou 10 para aumentar um coracao
                }
      



            }

            // caso colisao seja com a sujeira
            else if (gameObject.name == "Trash_Can(Clone)")
            {
				if (GameControllerDesktop.CenaAtual != "Modulo_espera_desktop" && GameControllerDesktop.CenaAtual != "Modulo_espera_acelerometro")
                {
                    SoundScript.Instance.MakeSujeiraSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido
                    GameController.Instance.MenosVida(); //diminui 1 coracao
                    GameController.maisVida = 0; //zera soma que aumentaria um coracao
                }
                else
                {
                    SoundScript.Instance.MakeSujeiraSound();// metodo do som
                    gameObject.SetActive(false); // apaga objeto colidido

                    GameControllerDesktop.Instance.MenosVida(); //diminui 1 coracao
                    GameControllerDesktop.maisVida = 0; //zera soma que aumentaria um coracao
                }


               
               
            }

            // fim higiene ------------------------------- 

		}// fim if
	}
}
