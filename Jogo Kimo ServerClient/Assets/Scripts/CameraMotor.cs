using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {


	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private float transition = 0.0f;
	//private float animationDuration = 1.0f;
	//private Vector3 animationOffset = new Vector3 (0,5,5);

	void Start () {

		//Encontra o player e pega sua posição
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
		
	}

	void Update () {

		//Para a camera seguir o player enquanto se movimenta
		moveVector = lookAt.position + startOffset;

		//x
		moveVector.x = 0;
		//y
		moveVector.y = Mathf.Clamp(moveVector.y,5,5);
		transform.position = moveVector;


		//-------------CÓDIGO PARA ANIMAÇÃO DE ABERTURA-----------------------

		/*if (transition > 1.0f) {
			transform.position = moveVector;

		} else {

			//Animação do início do jogo
			//transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
			transition += Time.deltaTime * 1 ;// animationDuration;
			//transform.LookAt (lookAt.position + Vector3.up) -->  Estava dando bug no Vector.up 
			transform.LookAt (lookAt.position + Vector3.forward); 

		}*/


		//transform.position = moveVector;
		
	}
}
