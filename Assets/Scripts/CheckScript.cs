using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    [SerializeField] private GameObject check = null;

    private SphereAddForce sphere = null;

    private void Start()
    {
        sphere = GameManager.Instance.ball.GetComponent<SphereAddForce>();

        sphere.ball = GameManager.Instance.limitBall[GameManager.Instance.selectionStageNumber];
        sphere.clearCount = GameManager.Instance.clearCount[GameManager.Instance.selectionStageNumber];
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
