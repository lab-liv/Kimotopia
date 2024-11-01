using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour {

	//Se contagem for regressiva, substituir "0" pelo tempo
	public float timer = 0;

	float oldTimer;
	bool isRunning = true;

	void Start ()
	{
		oldTimer = timer;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isRunning)
		{
			//Se contagem for regressiva, substituir "+" por "-"
			timer += Time.deltaTime;
			GetComponent<Text>().text = "Tempo: " + Mathf.RoundToInt(timer).ToString() + " ";

			//Somente se a contagem for regressiva
			if (timer < 0)
				isRunning = false;
		}
	}
}
