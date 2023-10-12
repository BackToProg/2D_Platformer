using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private Apple _apple;
    [SerializeField] private AppleSpawnPoint[] _spawnPoints;
    
    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            SpawnApple(spawnPoint.transform);
        }
    }

    private void SpawnApple(Transform spawnPoint)
    {
        Instantiate(_apple, spawnPoint.position, spawnPoint.rotation);
    }
}
