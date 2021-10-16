using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("instance가 null 입니다.");
                return null;
            }

            return instance;
        }

        private set
        {
            if (instance != null)
            {
                Debug.Log("이미 instance가 있습니다.");
                return;
            }

            instance = value;
        }
    }

    [SerializeField] private GameObject[] balls = null;
    [SerializeField] private Vector3[] ballPositions = null;

    public int[] limitBall = null;
    public int[] clearCount = null;

    public int selectionBallNumber = 0;
    public int selectionStageNumber = 0;

    [HideInInspector]
    public GameObject ball;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("이미 instance가 있습니다.");
            Destroy(this);

            return;
        }

        Instance = this;

        DontDestroyOnLoad(this);
    }

    public void GameStart()
    {
        ball = Instantiate(balls[selectionBallNumber], ballPositions[selectionStageNumber], Quaternion.Euler(-90f, 0f, 0f));
    }
}
