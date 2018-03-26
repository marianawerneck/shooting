using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openmainscene : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Gotonextscene(){
		Application.LoadLevel ("gameplay scene");
	} 
}
