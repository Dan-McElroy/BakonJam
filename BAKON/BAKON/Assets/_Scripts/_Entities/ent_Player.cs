using UnityEngine;
using System.Collections;

public enum RealityState{
	Realty_00,  // Neutral
	Reality_01,
	Reality_02
}

public class ent_Player : ent_Sprite {
	
	private RealityState realityState;
	
	// Use this for initialization
	void Start () {
	} // close Start()
	
	// Update is called once per frame
	void Update () {
	} // close void Update()
	
	
	public byte getReality()
	{
		return (byte)this.realityState;
	}
	
	public void setReality(RealityState val)
	{
		this.realityState = val;
	}
	
} // close ent_Player
