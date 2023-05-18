using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    private float startOnTopDelay = 2;
    private float startOnTheSidesDelay = 3;
    private float spawnOnTopInterval = 1.5f;
    private float spawnOnTheSidesInterval = 2.5f;
    private Quaternion spawnRot;


    private void Start() {
        InvokeRepeating("SpawnRandomAnimalOnTop", startOnTopDelay, spawnOnTopInterval);
        InvokeRepeating("SpawnRandomAnimalOnTheSides", startOnTheSidesDelay, spawnOnTheSidesInterval);
    }


    void Update()
    {
        
    }

    private void SpawnRandomAnimalOnTop() {
        float spawnRangeX = 20;
        float spawnPosZ = 20;

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    private void SpawnRandomAnimalOnTheSides() {
        float spawnMaxZ = 4;
        float spawnMinZ = -3;
        int[] spawnPositionsX = { 19, -19 };
        int spawnPosX = spawnPositionsX[Random.Range(0,2)];
        int direction = spawnPosX / Mathf.Abs(spawnPosX);
        

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnMinZ, spawnMaxZ));
        Vector3 spawnRotEuler = new Vector3(animalPrefabs[animalIndex].transform.rotation.x,
            animalPrefabs[animalIndex].transform.rotation.y - (90 * direction),
            animalPrefabs[animalIndex].transform.rotation.z);
        spawnRot.eulerAngles = spawnRotEuler;

        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRot);
    }
}
