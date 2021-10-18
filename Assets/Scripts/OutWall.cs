using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.BallOut();
        }
    }
}
