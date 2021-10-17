using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutWall : MonoBehaviour
{
    private SphereAddForce player = null;

    private void Start()
    {
        player = FindObjectOfType<SphereAddForce>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.ResetPlayer();
        }
    }
}
