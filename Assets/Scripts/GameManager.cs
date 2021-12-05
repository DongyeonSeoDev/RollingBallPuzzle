using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject[] balls = null;
    [SerializeField] private Vector3[] ballPositions = null;

    public int[] limitBall = null;
    public int[] clearCount = null;

    public int selectionBallNumber = 0;
    public int selectionStageNumber = 0;

    [HideInInspector]
    public GameObject ball;

    public bool[] stagePlay;

    [SerializeField] private Vector3[] addBallStageStartPositions = null;

    public int[] addBallStageLimitBall = null;
    public int[] addBallStageClearCount = null;

    public bool[] addBallStagePlay;

    public bool isAddBallStage = false;

    public bool[] selectBall;

    private SphereAddForce sphereAddForce;

    public bool isMute = false;

    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        base.Awake();

        DontDestroyOnLoad(this);
    }

    public void GameStart()
    {
        ball = Instantiate(balls[selectionBallNumber], isAddBallStage ? addBallStageStartPositions[selectionStageNumber] : ballPositions[selectionStageNumber], Quaternion.Euler(-90f, 0f, 0f));
        sphereAddForce = ball.GetComponent<SphereAddForce>();
    }

    public void BallOut()
    {
        sphereAddForce.ResetPlayer();
    }

    public static void GameClear()
    {
        UIManager.GameClear();

        if (Instance.selectionStageNumber < 0)
        {
            return;
        }

        if (Instance.isAddBallStage)
        {
            if (Instance.selectionStageNumber < Instance.addBallStagePlay.Length - 1)
            {
                Instance.addBallStagePlay[Instance.selectionStageNumber + 1] = true;
            }

            if (Instance.selectionStageNumber < Instance.selectBall.Length)
            {
                Instance.selectBall[Instance.selectionStageNumber] = true;
            }
        }
        else
        {
            if (Instance.selectionStageNumber < Instance.stagePlay.Length - 1)
            {
                Instance.stagePlay[Instance.selectionStageNumber + 1] = true;
            }
        }
    }
}
