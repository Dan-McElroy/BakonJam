using UnityEngine;
using System.Collections;

// Embarked upon by Daniel Emeritus McElroy at 22:24, Friday 24th January.
public class env_Level : MonoBehaviour {
	
	// 0 = neutral, 1 = playerOne, 2 = playerTwo
	public RealityState currentReality;

	public Transform bakonSpawnPoint;

	public Transform bakon;

	public GameObject[] realities;

	// Use this for initialization
	void Start () {
		bakon = GameObject.FindGameObjectWithTag ("Bakon").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnRealityAltered()
	{
		// Code to change level stuff
		realities [(int)RealityState.Reality_00].SetActive (currentReality == RealityState.Reality_00);
		realities [(int)RealityState.Reality_01].SetActive (currentReality == RealityState.Reality_01);
		realities [(int)RealityState.Reality_02].SetActive (currentReality == RealityState.Reality_02);
	}

	void Reset()
	{
		bakon.position = bakonSpawnPoint.position;
		// possibly alter current reality
	}
}
