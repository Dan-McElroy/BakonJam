﻿using UnityEngine;
using System.Collections;

public class env_Lava : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	void OnTriggerEnter2D (Collider2D coll)
	{
		
		if (coll.gameObject.tag=="Player") 
		{
			ent_Statistics obj = coll.gameObject.GetComponent<ent_Statistics>();
			obj.Kill();
		}
	}

}
