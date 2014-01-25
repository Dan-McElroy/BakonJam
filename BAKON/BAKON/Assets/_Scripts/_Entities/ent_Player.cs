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
		setMovement ();
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




	// Movement
	public void setMovement()
	{

		if (LeftControls)
		{
			PlayerMovement.movementUp = KeyCode.W;
			PlayerMovement.movementDown = KeyCode.S;
			PlayerMovement.movementLeft = KeyCode.A;
			PlayerMovement.movementRight = KeyCode.D;
		}
		else
		{
			PlayerMovement.movementUp = KeyCode.Keypad8;
			PlayerMovement.movementDown = KeyCode.Keypad2;
			PlayerMovement.movementLeft = KeyCode.Keypad4;
			PlayerMovement.movementRight = KeyCode.Keypad6;
		}

	}

	public void updateMovement()
	{

		float x = 0;
		float y = 0;
		float z = 0;




		// Move Up
		if (Input.GetKeyDown (PlayerMovement.movementUp)) { 
			y = -GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		}

		// Move Down
		if (Input.GetKeyDown (PlayerMovement.movementDown)) { 
			y = GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		}

		// Move Left
		if (Input.GetKeyDown (PlayerMovement.movementLeft)) { 
			x = -GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		}
		
		// Move Right
		if (Input.GetKeyDown (PlayerMovement.movementRight)) { 
			x = GetComponent<ent_Statistics>().CheckSpeed()*Time.deltaTime;
		}

		
		transform.position += new Vector3 (x, y, z);
	}
	
} // close ent_Player
