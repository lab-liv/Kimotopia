using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaM : MonoBehaviour {

	public GameObject orientacaoM;

	// Use this for initialization
	void Start () {

		orientacaoM.transform.Translate (-0.02f, 0.23f, 2.68f);
		StartCoroutine (Espera ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Espera ()
	{
		yield return new WaitForSeconds (5);
		orientacaoM.transform.Translate (100,0,0);
	}
}
