﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

	public GameObject timerTextView;
	public GameObject scoreTextView;
    public GameObject bazooka;
    public GameObject crossHair;
	public GameObject enemies;

	public ParticleSystem muzzleFlash;

	int gameTime = 10;
	int score = 0;

    AudioSource gunShotAudioSource;
    public AudioClip gunShotClip;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        gunShotAudioSource = gameObject.GetComponent<AudioSource>();
        InvokeRepeating ("TimeCounter", 0, 1);
		scoreTextView.GetComponent<Text>().text = score.ToString ();

	}

	void TimeCounter(){
		
		int min = (int)gameTime/60;
		int s = (int)gameTime % 60;
		timerTextView.GetComponent<Text> ().text = min.ToString () + ":" + s.ToString ().PadLeft (2,'0');

		if (min <= 0) {
			timerTextView.GetComponent<Text> ().color = Color.red;
		}

		if (gameTime <= 0) {
			GameOver ();
		}

        gameTime--;

    }

	void GameOver ()
	{
		score = 0;
		gameTime = 300;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Application.LoadLevel ("game over");
	}


	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.Confined;
        bazooka.transform.LookAt(crossHair.transform);

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        Vector3 crossHairMov = new Vector3(h,v,0);
        crossHair.transform.Translate(crossHairMov);

        float x = crossHair.transform.position.x;
        float y = crossHair.transform.position.y;

        if(x > 10.2)
        {
            x = 10.2f;
        }
        if(x < -10.2)
        {
            x = -10.2f;
        }
        if(y > 5.7)
        {
            y = 5.7f;
        }
        if(y < -5.7)
        {
            y = -5.7f;
        }
        crossHair.transform.position = new Vector3(x, y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


	}

    void Shoot()
    {
        gunShotAudioSource.PlayOneShot(gunShotClip);
		muzzleFlash.Emit (2);
		Vector2 dir = new Vector2 (crossHair.transform.position.x, crossHair.transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.transform.position, dir);
		if (hit.collider != null && hit.collider.gameObject.tag == enemies.gameObject.tag) {
			score++;
			Destroy (hit.collider.gameObject);

		}

		scoreTextView.GetComponent<Text>().text = score.ToString ();
    }


}
