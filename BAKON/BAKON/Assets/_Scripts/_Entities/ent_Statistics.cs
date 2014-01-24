using UnityEngine;
using System.Collections;

public class ent_Statistics : MonoBehaviour {
	
	
	// Variable declerations
	public int Health { get; private set; }
	public bool IsAlive { get; private set; }
	
	public int MoveSpeed { get; private set; }
	public float SprintMultiplier { get; private set; }
	public bool IsSprinting { get; private set; }
	
	
	
	
	// Use this for initialization
	void Start () {
	} // close Start()
	
	// Update is called once per frame
	void Update () {
		
		if (this.Health <= 0) { this.Kill (); } // Check entities health, if zero or below then kill
		
	} // close void Update()
	
	
	
	
	// health Functions
	public void SetHealth(int value)
	{
		this.Health = value;
	}
	
	public void Damage(int value)
	{
		Health -= value;
	} // close Damage(int value)
	
	public void Heal(int value)
	{
		Health += value;
	} // close Heal(int value)
	
	public void Kill()
	{
		this.Health = 0;
		this.IsAlive = false;
	}
	
	
	
	
	// Movement functions
	public int SetSpeed(int value)
	{
		this.MoveSpeed = value;
	}
	public int SetMultiplier(float value)
	{
		this.SprintMultiplier = value;
	}

	public int CheckSpeed()
	{
		if(this.IsSprinting){
			return this.MoveSpeed*this.SprintMultiplier;
		} else {
			return this.MoveSpeed;
		}
	}
	
	public void StartRunning()
	{
		this.IsSprinting = true;
	}
	
	public void StopRunning()
	{
		this.IsSprinting = false;
	}
	
} // close ent_Statistics
