﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour {

    GameObject metroite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "metroite") return;

        metroite = collision.gameObject;
    }
}
