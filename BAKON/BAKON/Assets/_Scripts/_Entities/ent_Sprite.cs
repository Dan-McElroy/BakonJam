using UnityEngine;
using System.Collections;

public class ent_Sprite : GameObject {
	
	protected ent_Statistics Statistics { get; set; }
	
	// Use this for initialization
	void Start () {
		Statistics = new ent_Statistics ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
