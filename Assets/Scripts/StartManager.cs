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

    public Button ballChangeButton;
    public Button[] ballButtons;

    public CanvasGroup ballChangeCanvasGroup;

    private bool isBallChange = false;

    private void Awake()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            int num = i;

            stages[num].stageButton.onClick.AddListener(() =>
            {
                GameManager.Instance.selectionStageNumber = num;
                SceneManager.LoadScene(stages[num].stageName);
            });
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

                DOTween.To(() => ballChangeCanvasGroup.alpha, x => ballChangeCanvasGroup.alpha = x, 0f, 0.5f).OnComplete(() =>
                {
                    ballChangeCanvasGroup.interactable = false;
                    ballChangeCanvasGroup.blocksRaycasts = false;
                });
            });
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
