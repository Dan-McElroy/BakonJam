using UnityEngine;
using System.Collections;

public class ent_Statistics : MonoBehaviour {
	
	
	// Variable declerations
	public int MaxHealth = 100;
	public int Health = 100;
	public int MoveSpeed = 10;
	public int Score { get; private set; }
	public float SprintMultiplier = 1.3f;

	public bool IsSprinting { get; private set; }
	
	
	
	
	// Use this for initialization
	void Start () {
	} // close Start()
	
	// Update is called once per frame
	void Update () {
		
		if (this.Health <= 0) { this.Kill (); } // Check entities health, if zero or below then kill
		
	} // close void Update()
	
	
	
	
	// health Functions	
	public void Kill()
	{
		this.Health = 0;
	}

	public void Revive()
	{
		this.Health = this.MaxHealth;
	}

	public bool IsAlive()
	{
		if(this.Health > 0) {
			return true;
		} else {
			return false;
		}
	}
	
	
	
	
	// Movement functions
	public void SetSpeed(int value)
	{
		this.MoveSpeed = value;
	}
	public void SetMultiplier(float value)
	{
		this.SprintMultiplier = value;
	}

	public float CheckSpeed()
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





	// Scoring
	public void AddScore()
	{
		this.Score++;
	}

	public void RemoveScore()
	{
		this.Score++;
	}

	public int GetScore()
	{
		return this.Score;
	}
	
} // close ent_Statistics
