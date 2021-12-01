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

        if (GameManager.Instance.isAddBallStage)
        {
            sphere.ball = GameManager.Instance.addBallStageLimitBall[GameManager.Instance.selectionStageNumber];
            sphere.clearCount = GameManager.Instance.addBallStageClearCount[GameManager.Instance.selectionStageNumber];
        }
        else
        {
            sphere.ball = GameManager.Instance.limitBall[GameManager.Instance.selectionStageNumber];
            sphere.clearCount = GameManager.Instance.clearCount[GameManager.Instance.selectionStageNumber];
        }

        UIManager.SetBallText(sphere.ball.ToString("00"));
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
