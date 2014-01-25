using UnityEngine;
using System.Collections;

public class env_Bakon : MonoBehaviour {
	
	public env_Level level;

	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Level").GetComponent<env_Level>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<ent_Player> () != null) 
		{
			RealityState newReality = (RealityState) coll.gameObject.GetComponent<ent_Player>().getReality();
			level.currentReality = newReality;
			level.BroadcastMessage("OnRealityAltered");
		}
	}
}
