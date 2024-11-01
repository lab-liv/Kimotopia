using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaH : MonoBehaviour {

	public GameObject orientacaoH;
	public int tempo1;
	public int tempo2;

	// Use this for initialization
	void Start () {

		tempo1 = 30;
		tempo2 = 30;

		StartCoroutine (Espera ());

	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Espera ()
	{
		yield return new WaitForSeconds (tempo1+tempo2+16);
		orientacaoH.transform.Translate (-0.02f, 0.1f, 2.68f);

		yield return new WaitForSeconds (5);
		orientacaoH.SetActive (false);
	}
}
