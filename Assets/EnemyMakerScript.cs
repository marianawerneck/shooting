using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerScript : MonoBehaviour {

    public GameObject enemy;
	public Sprite[] myImages;

	// Use this for initialization
	void Start () {
        InvokeRepeating("makeAnEnemy", 0, 3);
	}

    void makeAnEnemy()
    {
		GameObject newEnemy = (GameObject)Instantiate (enemy) as GameObject;
		float x = Random.Range (-13f, 13f);
		float y = -6;
		float z = 4;

		newEnemy.transform.position = new Vector3 (x, y, z);
		newEnemy.GetComponent<SpriteRenderer> ().sprite = myImages[Random.Range(0,myImages.Length)];
		newEnemy.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 400);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
