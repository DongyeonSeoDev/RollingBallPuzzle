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

    private SphereAddForce sphereAddForce;

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
        ball = Instantiate(balls[selectionBallNumber], ballPositions[selectionStageNumber], Quaternion.Euler(-90f, 0f, 0f));
        sphereAddForce = ball.GetComponent<SphereAddForce>();
    }

    public void BallOut()
    {
        sphereAddForce.ResetPlayer();
    }
}
