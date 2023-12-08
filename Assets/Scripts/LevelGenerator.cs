using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int countOfPlatform = 100;
    [SerializeField] private float minY = .1f;
    [SerializeField] private float maxY = 1f;
    [SerializeField] private float levelWidth = 3f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for(int i = 0; i != countOfPlatform; i++){
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
