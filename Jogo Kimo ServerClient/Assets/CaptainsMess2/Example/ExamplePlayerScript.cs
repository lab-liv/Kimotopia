using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using System.Collections;


public class ExamplePlayerScript : CaptainsMessPlayer
{
	public Image image;
	public Text nameField;
	public Text readyField;
	public Text rollResultField;
	public Text totalPointsField;

	public static float posx, posy, posz, vida;

	public static string point;

	public static Vector3[] valor_obj;
	public static Vector3[] valor_obj2;

	public static int c1;
	public static int c2;

	public static int i = 0;
	public static int j = 0;


	public static bool mudou_obj1;
	public static bool mudou_obj2;

	public static ExamplePlayerScript example;


	[SyncVar]
	public Color myColour;

	// Simple game states for a dice-rolling game

	[SyncVar]
	public int rollResult;

	[SyncVar]
	public int totalPoints;



	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();

		example = new GameObject ().AddComponent<ExamplePlayerScript> ();

		//Load scene for Server/Aplicador
		networkManager.ServerChangeScene("Modulo_aplicador");

		//Load scene for Client/Jogador
		//SceneManager.LoadSceneAsync("Modulo_espera", LoadSceneMode.Additive);





		// Send custom player info
		// This is an example of sending additional information to the server that might be needed in the lobby (eg. colour, player image, personal settings, etc.)

		//myColour = UnityEngine.Random.ColorHSV(0,1,1,1,1,1);
		//CmdSetCustomPlayerInfo(myColour);


	}

	[Command]
	public void CmdSetCustomPlayerInfo(Color aColour)
	{
		myColour = aColour;
	}

	[Command]
	public void CmdRollDie()
	{
		rollResult = UnityEngine.Random.Range(1, 7);
	}

	[Command]
	public void CmdPlayAgain()
	{
		ExampleGameSession.instance.PlayAgain();
	}


	[Command]
	public void CmdEnviar(float posx, float posy, float posz, string pt, float v)
	{

		AtivaReplica.Pontuacao (pt);
		PlayerMotor_Replica.Posicao (posx, posy, posz);
		AtivaReplica.Vida (v);

	}

	//objetos bons
	[Command]
	public void CmdObjetos (Vector3[] objetos1, int cont1)
	{
		AtivaReplica.Objetos (objetos1, cont1);
	}

	//objetos ruins
	[Command]
	public void CmdObjetos2 (Vector3[] objetos2, int cont2)
	{
		AtivaReplica.Objetos2 (objetos2, cont2);
	}

	[Command]
	public void CmdDestroy ()
	{
		AtivaReplica.destruicao ();
	}

	public static void Valores(float px, float py, float pz, string p, float v)
	{


		point = p;
		posx = px;
		posy = py;
		posz = pz;
		vida = v;


	}


	public static void Objetos_bons (float[] x, float[] y, float[] z, int cont1)
	{
		c1 = cont1;
		//Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa "+cont1+" nono "+c1);
		for (i = 0; i < cont1; i++) 
			valor_obj [i] = new Vector3 (x[i], y[i], z[i]);
		Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa "+cont1+" nono "+i);
		


	}

	public static void Objetos_ruins (float[] x, float[] y, float[] z, int cont2)
	{
		c2 = cont2;
		for (j = 0; j < cont2; j++) 
			valor_obj2 [j] = new Vector3 (x[j], y[j], z[j]);
		Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa "+cont2+" nono "+j);
		

	}


	public override void OnClientEnterLobby()
	{
		base.OnClientEnterLobby();

		// Brief delay to let SyncVars propagate
		Invoke("ShowPlayer", 0.5f);
	}

	public override void OnClientReady(bool readyState)
	{
		if (readyState)
		{
			readyField.text = "READY!";
			readyField.color = Color.green;
		}
		else
		{
			readyField.text = "not ready";
			readyField.color = Color.red;
		}
	}

	void ShowPlayer()
	{
		//transform.SetParent(GameObject.Find("Canvas/PlayerContainer").transform, false);

		image.color = myColour;	
		nameField.text = deviceName;
		readyField.gameObject.SetActive(true);

		rollResultField.gameObject.SetActive(false);
		totalPointsField.gameObject.SetActive(false);

		OnClientReady(IsReady());
	}

	public void Start ()
	{
		valor_obj = new Vector3[300];
		valor_obj2 = new Vector3[300];

		fase = "";


	}
	public string fase;
	public void FixedUpdate()
	{
		totalPointsField.text = "Points: " + totalPoints.ToString();
		if (rollResult > 0) {
			rollResultField.text = "Roll: " + rollResult.ToString();
		} else {
			rollResultField.text = "";
		}


		if (isLocalPlayer){

			CmdEnviar (posx, posy, posz, point, vida);

			if (GameController.destruicao) {
				CmdDestroy ();
				GameController.destruicao = false;
			}
			if (GameController.staticfase != fase && GameController.ehsujeira == true) {
				CmdObjetos (valor_obj, c1);
				CmdObjetos2 (valor_obj2, c2);
				GameController.ehsujeira = false;
			}
			fase = GameController.staticfase;

		}
	}

	[ClientRpc]
	public void RpcOnStartedGame()
	{
		readyField.gameObject.SetActive(false);

		rollResultField.gameObject.SetActive(true);
		totalPointsField.gameObject.SetActive(true);
	}

	/*void OnGUI()
	{
		if (isLocalPlayer)
		{
			GUILayout.BeginArea(new Rect(0, Screen.height * 0.8f, Screen.width, 100));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			ExampleGameSession gameSession = ExampleGameSession.instance;
			if (gameSession)
			{
				if (gameSession.gameState == GameState.Lobby ||
					gameSession.gameState == GameState.Countdown)
				{
					if (GUILayout.Button(IsReady() ? "Not ready" : "Ready", GUILayout.Width(Screen.width * 0.3f), GUILayout.Height(100)))
					{
						if (IsReady()) {
							SendNotReadyToBeginMessage();
						} else {
							SendReadyToBeginMessage();
						}
					}
				}
				else if (gameSession.gameState == GameState.WaitingForRolls)
				{
					if (rollResult == 0)
					{
						if (GUILayout.Button("Roll Die", GUILayout.Width(Screen.width * 0.3f), GUILayout.Height(100)))
						{
							CmdRollDie();
						}
					}
				}
				else if (gameSession.gameState == GameState.GameOver)
				{
					if (isServer)
					{
						if (GUILayout.Button("Play Again", GUILayout.Width(Screen.width * 0.3f), GUILayout.Height(100)))
						{
							CmdPlayAgain();
						}
					}
				}
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}*/
}
