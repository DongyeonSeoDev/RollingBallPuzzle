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

    public CanvasGroup ballChangeCanvasGroup;

    private bool isBallChange = false;

    private int nextStageNumber = 0;

    private Tween currentTween;
    public RectTransform stageSelectPosition;
    public float limitPosition;

    public Button settingButton = null;

    public GameObject settingPanel = null;
    public GameObject tutorialPlay = null;

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

                DOTween.To(() => ballChangeCanvasGroup.alpha, x => ballChangeCanvasGroup.alpha = x, 0f, 0.5f).OnComplete(() =>
                {
                    ballChangeCanvasGroup.interactable = false;
                    ballChangeCanvasGroup.blocksRaycasts = false;
                });
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

        settingButton.onClick.AddListener(() =>
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        });
    }

    private void Start()
    {
        if (!GameManager.Instance.isTutorialPlay)
        {
            tutorialPlay.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
