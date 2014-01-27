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




			// Check if we want to reassign target, if they hold the bacon
			foreach (ent_Player gameObj in FindObjectsOfType(typeof(ent_Player)) as ent_Player[])
			{

				// Distance between target and ai
				float playerDist = Vector3.Distance(this.transform.position, gameObj.transform.position);

				if((playerDist <= TargetRange) && gameObj.HasBacon) { 
					target = gameObj;
				}
			}




			// Check target has health
			if(target.GetComponent<ent_Statistics>().IsAlive())
			{
				
				// Distance between target and ai
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
					
					
					
					// Find the difference vector pointing from the character to the cursor
					Vector3 diff = this.target.transform.position - this.transform.position;
					// Always normalize the difference vector before using Atan2 function
					diff.Normalize();
					
					// calculate the Y rotation angle using atan2
					// Since you want Y rotation, the x component will remain the same,
					// but the 'y' component will need to the the z component instead
					// Atan2 will give you an angle in radians, so you
					// must use Rad2Deg constant to convert it to degrees
					float rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
					
					// now assign the roation using Euler angle function
					this.transform.rotation = Quaternion.Euler(0f,0f,rotZ);
					
					float xRotate = this.transform.localScale.x;
					float yRotate = this.transform.localScale.y;
					float zRotate = this.transform.localScale.z;
					if(xRotate < 0) { xRotate = -xRotate; }
					if(yRotate < 0) { yRotate = -yRotate; }
					
					
					if(this.transform.rotation.z <= 0.6f && this.transform.rotation.z >= -0.9f) {
						yRotate = -yRotate;
					}
					
					this.transform.localScale = new Vector3(-xRotate, -yRotate, zRotate);
					
				}
			}
			else
			{
				this.target = null;
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
