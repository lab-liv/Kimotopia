using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRDesable : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		XRSettings.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
