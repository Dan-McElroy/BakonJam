using UnityEngine;
using System.Collections;

// Embarked upon by Daniel Emeritus McElroy at 22:24, Friday 24th January.
public class env_Level : MonoBehaviour {
	
	// 0 = neutral, 1 = playerOne, 2 = playerTwo
	public RealityState currentReality;

	public GameObject[] realities;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnRealityAltered()
	{
		// Code to change level stuff
		realities [(int)RealityState.Reality_00].SetActive (currentReality != RealityState.Reality_00);
		realities [(int)RealityState.Reality_01].SetActive (currentReality != RealityState.Reality_01);
		realities [(int)RealityState.Reality_02].SetActive (currentReality != RealityState.Reality_02);

	}
}
