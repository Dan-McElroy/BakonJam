using UnityEngine;
using System.Collections;

public enum RealityState{
	Reality_00,  // Neutral
	Reality_01,
	Reality_02
}

public class ent_Player : ent_Sprite {

	private RealityState realityState;
	
	private struct MovementKeys
	{
		public KeyCode movementUp;
		public KeyCode movementDown;
		public KeyCode movementLeft;
		public KeyCode movementRight;
	}
	private MovementKeys PlayerMovement;
	
	public bool LeftControls = true;

	
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


		
		if (LeftControls)
		{
			x = Input.GetAxis ("LeftHorizontal")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("LeftVertical")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		} // close if (LeftControls)
		else
		{
			x = Input.GetAxis ("RightHorizontal")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
			y = Input.GetAxis ("RightVertical")*GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		}

		
		transform.position += new Vector3 (x, y, z);
	}
	
} // close ent_Player
