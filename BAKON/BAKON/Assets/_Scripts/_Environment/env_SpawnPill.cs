﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class env_SpawnPill : MonoBehaviour {

	public GameObject[] prefabs;
	public GameObject[] pills;
	public Transform[] pillSpawnPoints;
	public float[] spawnTimers;

	public float timerRangeLower, timerRangeUpper;

	private int playerCount; 

	private GameObject menu;

	// Use this for initialization
	void Start () {
		// pills should point to the in-game pill objects
		//pillSpawn
		// note: spawnTimers should have size set in editor
		menu = GameObject.Find ("MenuMain");

		List<Transform> availableSpawns = new List<Transform> (pillSpawnPoints);

		if(availableSpawns.Count > 0)
		{
			for (int i = 0; i < pills.Length; i++)
			{
				int index = Random.Range (0, availableSpawns.Count -1);


				pills[i] = (GameObject) Instantiate (prefabs[i], availableSpawns[index].position, Quaternion.identity);
				availableSpawns.RemoveAt(index);
			}
		}


		for (int i = 0; i < spawnTimers.Length; i++)
		{
			spawnTimers[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (playerCount == null && !menu.activeSelf)
		{
			playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
		}
		if (GameObject.FindGameObjectsWithTag("Pills").Length < pills.Length)
		{
			for (int i = 0; i < pills.Length; i++)
			{
				if (pills[i] == null && spawnTimers[i] < Time.time)
				{
					// pick an unused spawn point

					List<Transform> availableSpawns = new List<Transform>();
					for (int j = 0; j < pillSpawnPoints.Length; j++)
					{
						bool empty = true;
						foreach (GameObject activePill in GameObject.FindGameObjectsWithTag("Pills"))
						{
							if (activePill.transform == pillSpawnPoints[j])
								empty = false;
						}
						if (empty)
						{
							availableSpawns.Add (pillSpawnPoints[j]);
						}
					}
					if (availableSpawns.Count > 0)
					{
						Transform newSpawn = availableSpawns[Random.Range(0, (availableSpawns.Count-1))];
						pills[i] = (GameObject) Instantiate(prefabs[i], newSpawn.position, Quaternion.identity);
					}
				}
			}
		}
	}

	public void DestroyPill(GameObject pill)
	{
		for (int i = 0; i < pills.Length; i++)
		{
			if (pills[i] == pill)
			{
				spawnTimers[i] = Time.time + Random.Range (timerRangeLower*playerCount, timerRangeUpper*playerCount);
			}
		}
		Destroy(pill);
	}
}
