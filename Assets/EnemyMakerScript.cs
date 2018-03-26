using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerScript : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("makeAnEnemy", 0, 3);
	}

    void makeAnEnemy()
    {
        Debug.Log("Enemy");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
