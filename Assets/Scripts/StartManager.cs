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
    public CanvasGroup ballChangeCanvasGroup;

    private void Awake()
    {
        foreach (Stage stage in stages)
        {
            stage.stageButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(stage.stageName);
            });
        }

        ballChangeButton.onClick.AddListener(() =>
        {
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
