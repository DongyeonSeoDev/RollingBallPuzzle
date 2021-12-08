using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text remainBlockText;
    public Button reStartButton;
    public Button exitButton;

    private void Awake()
    {
        reStartButton.onClick.AddListener(() =>
        {
            UIManager.ReStartScene();
        });

        exitButton.onClick.AddListener(() =>
        {
            UIManager.ResetScene();
        });
    }

    public void GameOverProcess()
    {
        remainBlockText.text = $"남은 블록 수: {GameManager.Instance.sphereAddForce.clearCount - GameManager.Instance.sphereAddForce.puzzleCount}";
    }
}
