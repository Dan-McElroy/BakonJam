using UnityEngine;
using System.Collections;

public class env_Bakon : MonoBehaviour {



	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Level");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnCollisionEnter2D (Collision2D coll)
	{
		if ((ent_Player player = coll.gameObject.GetComponent<ent_Player> ()) != null) 
		{
			player.
		}
	}*/

}
