using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaA : MonoBehaviour {

	public GameObject orientacaoA;
	public int tempo1;

	// Use this for initialization
	void Start () {

		tempo1 = 30;

		StartCoroutine (Espera ());

	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Espera ()
	{
		yield return new WaitForSeconds (tempo1+8);
		orientacaoA.transform.Translate (-0.02f, 0.1f, 2.68f);

		yield return new WaitForSeconds (5);
		orientacaoA.SetActive (false);
	}
}
