using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : Pooling<ObstacleBall>
{
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float powerY = 0f;
    [SerializeField] private float powerZ = -50f;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartSpawnBall());
    }

    private IEnumerator StartSpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);

            var ball = GetPool();

            ball.ResetObject(spawnPosition, powerY, powerZ);
        }
    }
}