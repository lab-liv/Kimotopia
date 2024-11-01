using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameControllerDesktop : MonoBehaviour
{


	//objetos de cada fase
	public GameObject monstro;
	public GameObject medicacao;
	public GameObject hamburger;
	public GameObject ruim2;
	public GameObject ruim3;
	public GameObject ruim4;
	public GameObject alimentacao;
	public GameObject alimentacao2;
	public GameObject alimentacao3;
	public GameObject alimentacao4;
	public GameObject sujeira;
	public GameObject higiene;

	//para que haja vários objetos na mesma fase
	public GameObject[] objetos;
	public GameObject[] objetos2;
	public GameObject[] objetos3;
	public GameObject[] objetos4;
	public GameObject[] objetos_monstros;
	public GameObject[] objetos_monstros2;
	public GameObject[] objetos_monstros3;
	public GameObject[] objetos_monstros4;
	public GameObject go;
	public GameObject go2;
	public GameObject go3;
	public GameObject go4;
	public GameObject go_monstros;
	public GameObject go_monstros2;
	public GameObject go_monstros3;
	public GameObject go_monstros4;

	public float[] x_objetos_bons;
	public float[] y_objetos_bons;
	public float[] z_objetos_bons;

	public float[] x_objetos_ruins;
	public float[] y_objetos_ruins;
	public float[] z_objetos_ruins;

	public int cont_bons = 0;
	public int cont_ruins = 0;

	//para saber qual fase esta em execução
	public static bool playing_medicacao = false;
	public static bool playing_alimentacao = false;
	public static bool playing_higiene = false;
	public static bool playing_monstro = false;


	//nomes das fases
	private string fase_medicacao = "Medicacao";
	private string fase_alimentacao = "Alimentacao";
	private string fase_higiene = "Higiene";

	//variavel para esperar certo tempo apos pausar, para que o pause funcione
	private bool esperando = false;

	//para gerar números aleatórios
	public float range = 6;

	//eixo x dos objetos
	private float x = 0;

	//player
	public Transform playerTransform;

	//dificuldades do jogo
	public static float min_dificuldade = 0.2f;
	public static float max_dificuldade = 0.8f;

	public static string p;

	public static int pontuacao; //soma pontuacao da tela
	public Text points; //pontuacao na tela

	public static int maisVida; //soma de até 10 para aumentar um coracao

	private int sorteio;

	public static bool ehsujeira = false; //testa se deu tempo de criar todos os objetos

	public static int sorteio2 = 0;
	public static int sorteio3 = 0;
	public static int sorteio4 = 0;
	public static int sorteio5 = 0;
	public static int sorteio6 = 0;
	public static int sorteio7 = 0;
	public static int sorteio8 = 0;
	public static int sorteio9 = 0;


	public static int dificuldade_medicacao = 100; // valor padrão 100 
	public static int dificuldade_monstros = 25; // valor padrão 25 
	public static int dificuldade_alimentacao = 100; // valor padrão 100 
	public static int dificuldade_higiene = 5; // variavel de 1 a 8 - quantidade de lixos por linha

	//pode ser alterado pelo módulo do aplicador
	//tempo de cada fase em segundos (30 segundos no mínimo)
	public static float tempo_medicacao = 30.0f;
	public static float tempo_alimentacao = 30.0f;
	public static float tempo_higiene = 30.0f;

	// public SimpleHealthBar healthBar; // barrinha de vida na tela 
	public SimpleHealthBar healthBar;

	public static float vida; // variavel que controla a % da barrinha na tela


	//Juliana's test
	public string Texto;
	public Text teste;

	float px, py, pz;

	public static GameControllerDesktop Instance;

	public static bool destruicao = false;

	public int foifase;

	public static string CenaAtual;

	Fim fim = new Fim();




	//-------------------------------START-------------------------------------------
	void Start()
	{

		CenaAtual = SceneManager.GetActiveScene ().name;
		foifase = 0;


		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);


		vida = 10.0f;

		//retira todos os objetos ao iniciar jogo
		medicacao.SetActive(false);
		alimentacao.SetActive(false);
		higiene.SetActive(false);

		//inicia corotina para gerenciar tempo de execução de cada fase
		StartCoroutine(ControlaFases());


		maisVida = 0; //variavel de soma de até 10 para aumentar um coracao
		sorteio = 0;

		GameObject.Find("Player_Collisor").GetComponent<Player_Collider>().enabled = false; // colisor do player_collider

		GameObject.Find("Player_Collisor").GetComponent<Renderer>().enabled = false;

		pontuacao = 0;
	}

	//-------------------UPDATE-----------------------------------------------
	void FixedUpdate()
	{

		points = GameObject.Find("PontosText").GetComponent<Text>(); //pontuacao na tela
		points.text = "Pontos: " + pontuacao; //pontuacao na tela
		p = points.text;

		px = GameObject.Find("Player").transform.position.x;
		py = GameObject.Find("Player").transform.position.y;
		pz = GameObject.Find("Player").transform.position.z;
		ExamplePlayerScript.Valores(px, py, pz, p, vida);



	}


	public void MenosVida() //metodo para diminuir um coracao
	{
        Debug.Log("suhasuhsahusahushusahasuhshsauhsauhshusauhasuhasuhasuhsahusahusahusauhashusahusahuasuhsauhsahusahusahusahusahusahuashusahusahusahusahusahusahusauhsahusauasuhsahusa");
		PlayerMotor instanceOfPlayerMotor = GameObject.Find ("Player").GetComponent<PlayerMotor> ();
		vida = vida - 1.0f;
		if (vida < 1)
		{
			vida = 1;
			instanceOfPlayerMotor.Cor (true);


		}
		healthBar.UpdateBar(vida, 10.0f);



	}


	public void TestarSeMaisVida(int fase) //metodo para testar se aumenta 1 coracao
	{
		if (fase == 1) // fase medicacao
		{
			if (maisVida == 10) // 10 coletados certos e em seguida
			{
				vida = vida + 1.0f;
				if (vida > 10)
					vida = 10;
				//print(vida);
				healthBar.UpdateBar(vida, 10.0f); // aumenta % da barrinha na tela
				PlayerMotor instanceOfPlayerMotor = GameObject.Find ("Player").GetComponent<PlayerMotor> ();
				instanceOfPlayerMotor.Cor(false);
				maisVida = 0;
			}

		}//fase 1
		else if (fase == 2 || fase == 3) // fase higiene ou alimentacao
		{
			if (maisVida == 5) // 5 coletados certos e em seguida
			{
				vida = vida + 1.0f;
				if (vida > 10)
					vida = 10;
				//print(vida);
				healthBar.UpdateBar(vida, 10.0f); // aumenta % da barrinha na tela
				PlayerMotor instanceOfPlayerMotor = GameObject.Find ("Player").GetComponent<PlayerMotor> ();
				instanceOfPlayerMotor.Cor(false);
				maisVida = 0;
			}
		}


		if (pontuacao%10==0 && pontuacao!=0) //diminui monstros no jogo
		{

			GameObject.Find("Player_Collisor").GetComponent<Player_Collider>().enabled = true; //habilita script do colisor

		}
	}



	//-----------------------------------------
	//----------------- FASES -----------------
	//-----------------------------------------
	int q;
	IEnumerator ControlaFases()
	{
		while (true)
		{

			//inicia fase do monstro
			Start_Fase(fase_medicacao);

			cont_bons = 0;
			cont_ruins = 0;
			yield return new WaitForSeconds(8);
			yield return new WaitForSeconds(tempo_medicacao);
			Pause_Fase(fase_medicacao);
			destruicao = true;
			foifase++;
			q++;
			maisVida = 0;

			//inicia fase da comida
			Start_Fase(fase_alimentacao);
		
			cont_bons = 0;
			cont_ruins = 0;
			yield return new WaitForSeconds(8);
			yield return new WaitForSeconds(tempo_alimentacao);
			Pause_Fase(fase_alimentacao);
			destruicao = true;
			foifase++;
			q++;
			maisVida = 0;


			//inicia fase da sujeira
			Start_Fase(fase_higiene);

			cont_bons = 0;
			cont_ruins = 0;
			yield return new WaitForSeconds(8);
			yield return new WaitForSeconds(tempo_higiene);
			Pause_Fase(fase_higiene);
			destruicao = true;
			foifase++;
			q++;
			maisVida = 0;


		}

		//Add para controle pelo jogador 

		/*Start_Fase(fase_medicacao);
		yield return new WaitForSeconds(tempo_medicacao);
		Pause_Fase(fase_medicacao);

		//inicia fase da comida
		Start_Fase(fase_alimentacao);
		yield return new WaitForSeconds(tempo_alimentacao);
		Pause_Fase(fase_alimentacao);


		//inicia fase da sujeira
		Start_Fase(fase_higiene);
		yield return new WaitForSeconds(tempo_higiene);
		Pause_Fase(fase_higiene);



		//SceneManager.LoadScene ("Modulo_fim");*/

		fim.Recebe ();

	}

	public static bool Dificuldade(int x)
	{
		if (dificuldade_higiene == 8 && sorteio2 != x)
			return true;

		else if (dificuldade_higiene == 7 && sorteio2 != x && sorteio3 != x)
			return true;

		else if (dificuldade_higiene == 6 && sorteio2 != x && sorteio3 != x && sorteio4 != x)
			return true;

		else if (dificuldade_higiene == 5 && sorteio2 != x && sorteio3 != x && sorteio4 != x && sorteio5 != x)
			return true;

		else if (dificuldade_higiene == 4 && sorteio2 != x && sorteio3 != x && sorteio4 != x && sorteio5 != x && sorteio6 != x)
			return true;

		else if (dificuldade_higiene == 3 && sorteio2 != x && sorteio3 != x && sorteio4 != x && sorteio5 != x && sorteio6 != x && sorteio7 != x)
			return true;

		else if (dificuldade_higiene == 2 && sorteio2 != x && sorteio3 != x && sorteio4 != x && sorteio5 != x && sorteio6 != x && sorteio7 != x && sorteio8 != x)
			return true;

		else if (dificuldade_higiene == 1 && sorteio2 != x && sorteio3 != x && sorteio4 != x && sorteio5 != x && sorteio6 != x && sorteio7 != x && sorteio8 != x && sorteio9 != x)
			return true;
		else
			return false;
	}

	public static string staticfase;
	//--------------------------------START-----------------------------
	void Start_Fase (string fase)
	{
		staticfase = fase;
		int aux = 30; //variar posição inicial dos objetos depois do player
		int aux2 = 45; //variar posição máxima dos objetos depois do player
		int cont = 10;
		int cont2 = 10;//a cada 10 objetos - para que os objetos fiquem na mesma posição no eixo x
		float a = 1.5f;
		float b = 20f;

		//player - para poder pegar a posição dele
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;


		//quantidade de objetos que vão aparecer na fase
		//substituir número fixo por variável que será controlado pelo Módulo do Aplicador
		objetos = new GameObject[500];
		objetos2 = new GameObject[100];
		objetos3 = new GameObject[100];
		objetos4 = new GameObject[100];
		objetos_monstros = new GameObject[25];
		objetos_monstros2 = new GameObject[25];
		objetos_monstros3 = new GameObject[25];
		objetos_monstros4 = new GameObject[25];


		//-------------------------------------MEDICAÇÃO/MONSTROS	
		if (fase == fase_medicacao)
		{

			playing_medicacao = true;
			playing_monstro = true;

			x_objetos_bons = new float[100];
			y_objetos_bons = new float[100];
			z_objetos_bons = new float[100];

			x_objetos_ruins = new float[100];
			y_objetos_ruins = new float[100];
			z_objetos_ruins = new float[100];
			//--------------------MEDICAMENTOS
			//aparece vários objetos em várias posições para serem coletados
			for (int i = 0; i < dificuldade_medicacao; i++)
			{

				if (cont == 10)
				{
					x = Random.Range(-4.5f, 4.5f);//limites laterais do caminho
					cont = 0;
					aux = aux2; //os objetos começam a aparecer depois do última posiçãa máxima
					aux2 = aux2 + 20; //para que os próximos 10 objetos não fiquem tão próximos dos anteriores
					a = 1.5f;
				}

				go = Instantiate(medicacao) as GameObject;
				go.SetActive(true);
				go.transform.position = new Vector3(x, 0.5f, playerTransform.position.z + aux + a);

				//vetor de objetos da fase
				objetos[i] = go;
				cont++;

				a = a + 1.5f;


			}


			//-----------------MONSTROS-----------------------------------
			for (int j = 0; j < dificuldade_monstros; j++)
			{

				go_monstros = Instantiate(monstro) as GameObject;
				go_monstros.SetActive(true);
				go_monstros.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + b);

				//vetor de objetos da fase
				objetos_monstros[j] = go_monstros;

				b = b + 5;


			}
			ehsujeira = true;

		} // fim da fase

		//---------------------------------------------ALIMENTAÇÃO	
		else if (fase == fase_alimentacao)
		{

			x_objetos_bons = new float[100];
			y_objetos_bons = new float[100];
			z_objetos_bons = new float[100];

			x_objetos_ruins = new float[100];
			y_objetos_ruins = new float[100];
			z_objetos_ruins = new float[100];

			playing_alimentacao = true;

			for (int i2 = 0; i2 < dificuldade_alimentacao; i2++)
			{
				sorteio = Random.Range(1, 9); // alimento a ser sorteado

				//alimento saudavel 1 -----------------------------------------------------
				if(sorteio == 1){
					go = Instantiate(alimentacao) as GameObject;
					go.SetActive(true);
					go.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);



					//vetor de objetos da fase
					objetos[i2] = go;
					a = a + 3;

				}

				//-----------------HAMBURGER-----------------------------
				else if(sorteio == 2)
				{
					go_monstros = Instantiate(hamburger) as GameObject;
					go_monstros.SetActive(true);
					go_monstros.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);


					//vetor de objetos da fase
					objetos[i2] = go_monstros;

				


					a = a + 3;
				}

				//alimento saudavel 2 -----------------------------------------------------
				else if (sorteio == 3)
				{
					go2 = Instantiate(alimentacao2) as GameObject;
					go2.SetActive(true);
					go2.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);


					//vetor de objetos da fase
					objetos[i2] = go2;
					a = a + 3;

				}

				//-----------------alimento ruim 2-----------------------------
				else if(sorteio == 4)
				{
					go_monstros2 = Instantiate(ruim2) as GameObject;
					go_monstros2.SetActive(true);
					go_monstros2.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);

					//vetor de objetos da fase
					objetos[i2] = go_monstros2;

			

					a = a + 3;
				}

				//alimento saudavel 3 -----------------------------------------------------
				else if(sorteio == 5)
				{
					go3 = Instantiate(alimentacao3) as GameObject;
					go3.SetActive(true);
					go3.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);


					//vetor de objetos da fase
					objetos[i2] = go3;
					a = a + 3;

				}

				//-----------------alimento ruim 3 -----------------------------
				else if(sorteio == 6)
				{
					go_monstros3 = Instantiate(ruim3) as GameObject;
					go_monstros3.SetActive(true);
					go_monstros3.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);


					//vetor de objetos da fase
					objetos[i2] = go_monstros3;


					a = a + 3;
				}

				//alimento saudavel 4 -----------------------------------------------------
				else if(sorteio == 7)
				{
					go4 = Instantiate(alimentacao4) as GameObject;
					go4.SetActive(true);
					go4.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);


					//vetor de objetos da fase
					objetos[i2] = go4;
					a = a + 3;

				}

				//-----------------alimento ruim 4 -----------------------------
				else if(sorteio == 8)
				{
					go_monstros4 = Instantiate(ruim4) as GameObject;
					go_monstros4.SetActive(true);
					go_monstros4.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, playerTransform.position.z + 30 + a);

					//vetor de objetos da fase
					objetos[i2] = go_monstros4;

		

					a = a + 3;
				}

			} /////////////////fim do for

			ehsujeira = true;

		} /////////////////fim da fase


		//--------------------------------------------- SUJEIRA e HIGIENE-------------
		else if (fase == fase_higiene)
		{


			sorteio2 = 0;
			playing_higiene = true;

			int array_posicao = 0;

			x_objetos_bons = new float[300];
			y_objetos_bons = new float[300];
			z_objetos_bons = new float[300];

			x_objetos_ruins = new float[300];
			y_objetos_ruins = new float[300];
			z_objetos_ruins = new float[300];

			for (int j = 0; j < 30; j++) // fileiras de lixo
			{
				sorteio2 = Random.Range(0, 9); 

				if (dificuldade_higiene < 2) //dificuldade=1
					do { sorteio9 = Random.Range(0, 9); }
				while (sorteio9 == sorteio2);

				if (dificuldade_higiene < 3) //dificuldade=1 ou 2
					do { sorteio8 = Random.Range(0, 9); }
				while (sorteio8 == sorteio9 || sorteio8 == sorteio2);

				if (dificuldade_higiene < 4) //dificuldade=1 ou 2 ou 3
					do { sorteio7 = Random.Range(0, 9); }
				while (sorteio7 == sorteio8 || sorteio7 == sorteio9 || sorteio7 == sorteio2);

				if (dificuldade_higiene < 5) //dificuldade=1 ou 2 ou 3 ou 4
					do { sorteio6 = Random.Range(0, 9); }
				while (sorteio6 == sorteio7 || sorteio6 == sorteio8 || sorteio6 == sorteio9 || sorteio6 == sorteio2);

				if (dificuldade_higiene < 6) //dificuldade=1 ou 2 ou 3 ou 4 ou 5
					do { sorteio5 = Random.Range(0, 9); }
				while (sorteio5 == sorteio9 || sorteio5 == sorteio8 || sorteio5 == sorteio7 || sorteio5 == sorteio6 || sorteio5 == sorteio2);

				if (dificuldade_higiene < 7) //dificuldade=1 ou 2 ou 3 ou 4 ou 5 ou 6
					do { sorteio4 = Random.Range(0, 9); }
				while (sorteio4 == sorteio9 || sorteio4 == sorteio8 || sorteio4 == sorteio7 || sorteio4 == sorteio6 || sorteio4 == sorteio2 || sorteio4 == sorteio5);

				if (dificuldade_higiene < 8) //dificuldade=1 ou 2 ou 3 ou 4 ou 5 ou 6 ou 7
					do { sorteio3 = Random.Range(0, 9); }
				while (sorteio3 == sorteio9 || sorteio3 == sorteio8 || sorteio3 == sorteio7 || sorteio3 == sorteio6 || sorteio3 == sorteio2 || sorteio3 == sorteio5 || sorteio3 == sorteio4);


				for (int x = 0; x < 9; x += 1) // objetos por linha
				{
					array_posicao = 10 * j + x;
					if (Dificuldade(x)) // posicoes com lixo
					{
						go_monstros = Instantiate(sujeira) as GameObject;
						go_monstros.SetActive(true);
						go_monstros.transform.position = new Vector3(x - 4, 0.5f, playerTransform.position.z + 30 + b);


						//vetor de objetos da fase
						objetos[array_posicao] = go_monstros;



					}
					else // espaco em branco para passagem
					{
						go = Instantiate(higiene) as GameObject;
						go.SetActive(true);
						go.transform.position = new Vector3(x - 4, 0.5f, playerTransform.position.z + 30 + b);


						//vetor de objetos da fase
						objetos[array_posicao] = go;

					
					}
				}
				b = b + 7; // espaco para proxima fileira de lixos
			}

			ehsujeira = true;

		} // fim da fase
	}

	//----------------------------------------- PAUSE ----------------------
	void Pause_Fase(string fase)
	{
		destruicao = true;
		if (fase == fase_medicacao)
		{
			//pausa o update do MoveMonstro
			playing_medicacao = false;
			playing_monstro = false;
			//desativa os objetos na tela
			medicacao.SetActive(false);
			monstro.SetActive (false);

			//destrói todos os objetos da fase quando a mesma é terminada
			for (int i = 0; i < 100; i++)
				Destroy (objetos[i]);

			for (int j = 0; j < 25; j++)
				Destroy (objetos_monstros[j]);
		}
		else if (fase == fase_alimentacao)
		{
			//pausa o update do MoveComida
			playing_alimentacao = false;
			//desativa os objetos na tela
			alimentacao.SetActive(false);
			alimentacao2.SetActive(false);
			alimentacao3.SetActive(false);
			alimentacao4.SetActive(false);
			hamburger.SetActive(false);
			ruim2.SetActive(false);
			ruim3.SetActive(false);
			ruim4.SetActive(false);

			for (int i = 0; i < 100; i++)
			{
				Destroy(objetos[i]);
			}

		}
		else if (fase == fase_higiene)
		{
			//pausa o update do MoveSujeira
			playing_higiene = false;
			//desativa os objetos na tela
			higiene.SetActive(false);
			sujeira.SetActive(false);

			for (int i = 0; i < 500; i++) 
			{
				Destroy(objetos[i]);
			}		
		}
	}

	//----------------------------------------
	//----------------- MENU -----------------
	//----------------------------------------



	IEnumerator WaitSeconds ()
	{   //delay de alguns segundos
		//esperando = true;
		yield return new WaitForSeconds(3f);
		//esperando = false;
	}



}
