using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject spawnBall = null;
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;

    private void Start()
    {
        StartCoroutine(StartSpawnBall());
    }

    private IEnumerator StartSpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(spawnBall, spawnPosition, Quaternion.identity);
        }
    }
}
