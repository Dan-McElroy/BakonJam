using UnityEngine;
using System.Collections;

public class env_Bakon : MonoBehaviour {
	
	public env_Level level;
	public Transform pedestal;

	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Level").GetComponent<env_Level>();
		pedestal = GameObject.FindGameObjectWithTag ("bacon_pedestal").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{

		if (coll.gameObject.tag=="Player") 
		{
			transform.parent = coll.gameObject.transform;
			ent_Player playerWithBacon = coll.gameObject.GetComponent<ent_Player>();


			playerWithBacon.HasBacon = true;
			foreach (ent_Player player in FindObjectsOfType(typeof(ent_Player)) as ent_Player[])
			{
				if(player.gameObject != coll.gameObject) {
					player.HasBacon = false;
				}
			}
			///ChangeReality (coll.gameObject.GetComponent<ent_Player>());
		}
	}

	void ChangeReality(ent_Player player)
	{
		level.currentReality = (RealityState)player.getReality ();
		level.BroadcastMessage ("OnRealityAltered");
	}

	public void Reset()
	{
		transform.position = pedestal.position;
	}
}
