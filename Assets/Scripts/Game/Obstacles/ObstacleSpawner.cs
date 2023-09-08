using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float _spawnTime;

    private float _spawnTimer;

    private void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();

        if (_spawnTimer > 0) return;

        SpawnObstacle();
        ResetTimer();
    }

    private void Countdown() => _spawnTimer -= Time.deltaTime; 

    private void ResetTimer()
    {
        _spawnTimer = _spawnTime;
    }

    private void SpawnObstacle()
    {
        Obstacle unPooledObstacle = ObstaclePooler.Instance.EnableObstacle();

        unPooledObstacle.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        unPooledObstacle.gameObject.SetActive(true);
    }
}
