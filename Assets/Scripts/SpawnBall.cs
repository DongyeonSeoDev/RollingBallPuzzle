using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : Pooling<ObstacleBall>
{
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartSpawnBall());
    }

    private IEnumerator StartSpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            var ball = GetPool();

            ball.ResetObject(spawnPosition);
        }
    }
}