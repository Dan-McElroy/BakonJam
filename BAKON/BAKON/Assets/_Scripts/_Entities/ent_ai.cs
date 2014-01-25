using UnityEngine;
using System.Collections;

public enum AIState {
	idle,
	chase
}

public class ent_ai : MonoBehaviour {

	public float TargetRange = 100;
	public float MoveSpeed = 5f;

	private AIState ai_state = AIState.idle;
	public ent_Player target = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(target == null)
		{
			this.ai_state = AIState.idle;
			float minDistance = -1f;

			//You probably want a more specific type than GameObject
			foreach (ent_Player gameObj in FindObjectsOfType(typeof(ent_Player)) as ent_Player[])
			{
				float targetDist = Vector3.Distance(this.transform.position, gameObj.transform.position);
				if(minDistance == -1f || targetDist < minDistance)
				{
					minDistance = targetDist;
					this.target = gameObj;
				}
			}

		}
		else
		{
			float targetDist = Vector3.Distance(this.transform.position, target.transform.position);
			if(targetDist > TargetRange)
			{
				this.target = null;
				this.ai_state = AIState.idle;
			}
			else
			{

				// We are in range of target and can chase
				Vector3 direction = this.target.transform.position - this.transform.position;
				direction.Normalize();

				Vector3 velocity = Vector3.Scale(direction, new Vector3(MoveSpeed*Time.deltaTime, MoveSpeed*Time.deltaTime, 0f));
				this.transform.position += velocity;

			}

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


}
