﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class env_SpawnPill : MonoBehaviour {

	public GameObject[] pills;
	public Transform[] pillSpawnPoints;
	public float[] spawnTimers;

	// Use this for initialization
	void Start () {
		// pills should point to the in-game pill objects
		//pillSpawn
		// note: spawnTimers should have size set in editor
		for (int i = 0; i < spawnTimers.Length; i++)
		{
			spawnTimers[i] = Time.time + Random.Range (2, 7);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Pills").Length < 3)
		{
			for (int i = 0; i < pills.Length; i++)
			{
				if (!pills[i].activeSelf && spawnTimers[i] < Time.time)
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
						pills[i].transform.position = newSpawn.position;
						pills[i].SetActive(true);
					}
				}
			}
		}
	}

	void DestroyPill(GameObject pill)
	{
		for (int i = 0; i < pills.Length; i++)
		{
			if (pills[i] == pill)
			{
				pills[i].SetActive(false);
				spawnTimers[i] = Time.time + Random.Range (2, 7);

			}
		}
	}
}