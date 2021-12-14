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

    public SphereAddForce sphereAddForce;

    public bool isMute = false;

    public bool isTutorialPlay = false;

    [HideInInspector]
    public TutorialManager tutorial;

    public int addBallNumber = -1;

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

    private void Start()
    {
        SaveAndLoad.InitSaveAndLoad();
        GameManager data = (GameManager)SaveAndLoad.Load();
    }

    public static void CheckEscape(GameEnd gameEnd)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameEnd.ChangeUI();
        }
    }

    public static void Save()
    {
        SaveAndLoad.Save((GameData)Instance);
    }

    public void GameStart()
    {
        if (tutorial != null)
        {
            ball = Instantiate(balls[selectionBallNumber], ballPositions[0], Quaternion.Euler(-90f, 0f, 0f));
        }
        else
        {
            ball = Instantiate(balls[selectionBallNumber], isAddBallStage ? addBallStageStartPositions[selectionStageNumber] : ballPositions[selectionStageNumber], Quaternion.Euler(-90f, 0f, 0f));
        }

        sphereAddForce = ball.GetComponent<SphereAddForce>();
        sphereAddForce.ResetPlayer();
    }

    public void BallOut()
    {
        sphereAddForce.ResetPlayer();
    }

    public static void GameClear()
    {
        if (Instance.tutorial != null)
        {
            Instance.tutorial.FillBlock();
        }
        else
        {
            Instance.Invoke("GameClearProcess", 1f);
        }
    }

    private void GameClearProcess()
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
                GameManager.Save();
            }

            if (Instance.selectionStageNumber + 2 < Instance.selectBall.Length && !Instance.selectBall[Instance.selectionStageNumber + 2])
            {
                Instance.selectBall[Instance.selectionStageNumber + 2] = true;
                addBallNumber = Instance.selectionStageNumber + 2;
                GameManager.Save();
            }
        }
        else
        {
            if (Instance.selectionStageNumber < Instance.stagePlay.Length - 1)
            {
                Instance.stagePlay[Instance.selectionStageNumber + 1] = true;
                GameManager.Save();
            }
        }
    }
}
