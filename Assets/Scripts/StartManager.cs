using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

[System.Serializable]
public class Stage
{
    public Button stageButton;
    public string stageName;
}

public class StartManager : MonoBehaviour
{
    public Stage[] stages;
    public Stage[] addBallStages;

    public Button ballChangeButton;
    public Button[] ballButtons;
    public Button ballChangeCloseButton;

    public CanvasGroup ballChangeCanvasGroup;

    private bool isBallChange = false;

    private int nextStageNumber = 0;

    private Tween currentTween;
    public RectTransform stageSelectPosition;
    public float limitPosition;

    public Button settingButton = null;

    public GameObject settingPanel = null;
    public GameObject tutorialPlay = null;

    public GameEnd gameEnd;

    public GameObject addBallPanel;
    public Image ballImage;
    public Button checkButton;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager가 없습니다.");
            Debug.LogWarning("게임은 StartGameScene에서 시작해야 합니다.");

            SceneManager.LoadScene("StartGameScene");

            return;
        }

        for (int i = 0; i < stages.Length; i++)
        {
            int num = i;

            stages[num].stageButton.onClick.AddListener(() =>
            {
                GameManager.Instance.selectionStageNumber = num;
                GameManager.Instance.isAddBallStage = false;

                if (currentTween != null && currentTween.IsActive())
                {
                    currentTween.Complete();
                    currentTween.Kill();
                }

                SceneManager.LoadScene(stages[num].stageName);
                SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            });

            stages[num].stageButton.interactable = GameManager.Instance.stagePlay[num];

            if (GameManager.Instance.stagePlay[num])
            {
                nextStageNumber = num;
            }
        }

        currentTween = stageSelectPosition.DOAnchorPosY(Mathf.Clamp((nextStageNumber + (nextStageNumber % 2 == 0 ? 0 : -1)) * 350f, 0, limitPosition), 1f);

        for (int i = 0; i < addBallStages.Length; i++)
        {
            int num = i;

            addBallStages[num].stageButton.onClick.AddListener(() =>
            {
                GameManager.Instance.selectionStageNumber = num;
                GameManager.Instance.isAddBallStage = true;

                if (currentTween != null && currentTween.IsActive())
                {
                    currentTween.Complete();
                    currentTween.Kill();
                }

                SceneManager.LoadScene(addBallStages[num].stageName);
                SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            });

            addBallStages[num].stageButton.interactable = GameManager.Instance.addBallStagePlay[num];
        }

        for (int i = 0; i < ballButtons.Length; i++)
        {
            int num = i;

            ballButtons[num].onClick.AddListener(() =>
            {
                if (!isBallChange)
                {
                    return;
                }

                isBallChange = false;

                GameManager.Instance.selectionBallNumber = num;

                BallUIManager.Instance.uiImage.sprite = BallUIManager.Instance.ballSprites[num];

                BallClose();
            });

            ballButtons[num].interactable = GameManager.Instance.selectBall[num];
        }

        ballChangeButton.onClick.AddListener(() =>
        {
            if (isBallChange)
            {
                return;
            }

            isBallChange = true;

            DOTween.To(() => ballChangeCanvasGroup.alpha, x => ballChangeCanvasGroup.alpha = x, 1f, 0.5f);

            ballChangeCanvasGroup.interactable = true;
            ballChangeCanvasGroup.blocksRaycasts = true;
        });

        ballChangeCloseButton.onClick.AddListener(() =>
        {
            BallClose();
        });

        settingButton.onClick.AddListener(() =>
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        });

        checkButton.onClick.AddListener(() =>
        {
            addBallPanel.SetActive(false);
        });
    }

    private void Start()
    {
        if (!GameManager.Instance.isTutorialPlay)
        {
            tutorialPlay.SetActive(true);
        }

        AddBall();
    }

    private void Update()
    {
        GameManager.CheckEscape(gameEnd);
    }

    private void BallClose()
    {
        DOTween.To(() => ballChangeCanvasGroup.alpha, x => ballChangeCanvasGroup.alpha = x, 0f, 0.5f).OnComplete(() =>
        {
            ballChangeCanvasGroup.interactable = false;
            ballChangeCanvasGroup.blocksRaycasts = false;

            isBallChange = false;
        });
    }

    private void AddBall()
    {
        if (GameManager.Instance.addBallNumber >= 0)
        {
            addBallPanel.SetActive(true);
            ballImage.sprite = BallUIManager.Instance.ballSprites[GameManager.Instance.addBallNumber];
            GameManager.Instance.addBallNumber = -1;
        }
    }
}
