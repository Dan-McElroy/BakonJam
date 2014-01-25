using UnityEngine;
using System.Collections;

public enum RealityState{
	Reality_00,  // Neutral
	Reality_01,
	Reality_02
}

public enum MovementControls
{
	Movement_01,
	Movement_02,
	Movement_03,
	Movement_04,
	Movement_05,
	Movement_06
}

public class ent_Player : ent_Sprite {
	
	public RealityState realityState = RealityState.Reality_00;
	public MovementControls movementControls = MovementControls.Movement_01;
	
	private struct MovementKeys
	{
		public KeyCode movementUp;
		public KeyCode movementDown;
		public KeyCode movementLeft;
		public KeyCode movementRight;
	}

	private MovementKeys PlayerMovement;
	public bool IsRespawning = false;
	public bool HasBacon = false;
	
	
	// Use this for initialization
	void Start () {
	} // close Start()
	
	// Update is called once per frame
	void Update () {
		this.updateMovement();
	} // close void Update()
	
	
	public byte getReality()
	{
		return (byte)this.realityState;
	}
	
	public void setReality(RealityState val)
	{
		this.realityState = val;
	}
	
	public void updateMovement()
	{
		
		float x = 0;
		float y = 0;
		float z = 0;
		
		switch(movementControls)
		{
		case MovementControls.Movement_01:
			x = Input.GetAxis ("Horizontal_01")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_01")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
			
		case MovementControls.Movement_02:
			x = Input.GetAxis ("Horizontal_02")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_02")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
			
		case MovementControls.Movement_03:
			x = Input.GetAxis ("Horizontal_03")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_03")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
			
		case MovementControls.Movement_04:
			x = Input.GetAxis ("Horizontal_04")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_04")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
			
		case MovementControls.Movement_05:
			x = Input.GetAxis ("Horizontal_05")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_05")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
			
		case MovementControls.Movement_06:
			x = Input.GetAxis ("Horizontal_06")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("Vertical_06")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			break;
		}
		
		
		transform.position += new Vector3 (x, y, z);
	}
	
} // close ent_Player
