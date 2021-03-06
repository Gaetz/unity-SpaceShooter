﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hasardCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    void Start () {
        StartCoroutine(SpawnWaves());
	}
	
	void Update () {
		
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        Quaternion spawnRotation = Quaternion.identity;
        while (true) {
            for (int i = 0; i < hasardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
