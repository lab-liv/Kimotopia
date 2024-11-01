using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhoManager : MonoBehaviour {

	public GameObject[] caminhoPrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float caminhoLength = 7.58f;
	private int amnCaminhoOnScreen = 10;

	private void Start () {

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnCaminhoOnScreen; i++) {
			SpawnCaminho ();
		}

	}

	private void Update () {

		if (playerTransform.position.z > (spawnZ - amnCaminhoOnScreen * caminhoLength)) {
			SpawnCaminho ();
		}

	}

	//função para criar o caminho durante o jogo
	private void SpawnCaminho (int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (caminhoPrefabs [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += caminhoLength;
	}
}
