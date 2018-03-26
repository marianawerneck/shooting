using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Wait");
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("main menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
