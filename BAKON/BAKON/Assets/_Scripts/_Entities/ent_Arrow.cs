using UnityEngine;
using System.Collections;

public class ent_Arrow : MonoBehaviour {

	public Vector3 Direction = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newDir = Direction;
		Vector3 extraTurn = Vector3.zero;
		bool hasMoved = false;

		// If there is someone with bacon, 'veer off' to them
		foreach (ent_Player gameObj in FindObjectsOfType(typeof(ent_Player)) as ent_Player[])
		{

			if(gameObj.HasBacon)
			{
				
				// Check if arrow is 'behind' player based on current positions and direction
				Vector3 playerPos = gameObj.transform.position;
				Vector3 thisPos = this.transform.position;

				var step = (this.GetComponent<ent_Statistics>().MoveSpeed * Time.deltaTime * 0.4f);
				// Move our position a step closer to the target.

				transform.position = 
					Vector3.MoveTowards(thisPos, playerPos, step) +
					Vector3.Scale(newDir, new Vector3(this.GetComponent<ent_Statistics>().MoveSpeed*Time.deltaTime, this.GetComponent<ent_Statistics>().MoveSpeed*Time.deltaTime, 0f));

				hasMoved = true;

			}
		}

		if(!hasMoved) {
			Vector3 velocity = Vector3.Scale(newDir, new Vector3(this.GetComponent<ent_Statistics>().MoveSpeed*Time.deltaTime, this.GetComponent<ent_Statistics>().MoveSpeed*Time.deltaTime, 0f));
			this.transform.position += velocity;
			hasMoved = true;
		}
	
	}

	
	void OnCollisionEnter2D (Collision2D coll)
	{
		
		if (coll.gameObject.tag=="Player") 
		{
			ent_Statistics obj = coll.gameObject.GetComponent<ent_Statistics>();
			obj.Kill();
		}
	}


	void OnBecameInvisible () {
		ent_Statistics statistics = this.gameObject.GetComponent<ent_Statistics> ();
		statistics.Kill ();
	}
}
