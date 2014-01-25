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
		print ("collison");

		if (coll.gameObject.tag=="Player") 
		{
			transform.parent = coll.gameObject.transform;
			ChangeReality (coll.gameObject.GetComponent<ent_Player>());
		}
	}

	void ChangeReality(ent_Player player)
	{
		level.currentReality = (RealityState)player.getReality ();
		level.BroadcastMessage ("OnRealityAltered");
	}

	// NEXT JOB: HANDLING BAKON DROPPING

}
