using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    [SerializeField] private GameObject check = null;

    private SphereAddForce sphere = null;

    private void Awake()
    {
        sphere = FindObjectOfType<SphereAddForce>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            check.SetActive(true);
            sphere.hiddenResetPlayer();
            gameObject.SetActive(false);
        }
    }
}
