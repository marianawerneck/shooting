using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

	public GameObject timerTextView;

	int gameTime = 5;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("TimeCounter", 1, 1);

	}

	void TimeCounter(){
		gameTime--;
		int min = (int)gameTime/60;
		int s = (int)gameTime % 60;
		timerTextView.GetComponent<Text> ().text = min.ToString () + ":" + s.ToString ().PadLeft (2,'0');

		if (min <= 0) {
			timerTextView.GetComponent<Text> ().color = Color.red;
		}

		if (gameTime <= 0) {
			GameOver ();
		}


	}

	void GameOver ()
	{
		Application.LoadLevel ("game over");
		StartCoroutine("Wait");

	}


	IEnumerator Wait(){
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("main menu");
		yield return null;
	}

	
	// Update is called once per frame
	void Update () {
		

	}


}
