using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public Text remainBallText;
    public Button exitButton;

    private void Awake()
    {
        exitButton.onClick.AddListener(() =>
        {
            UIManager.ResetScene();
        });
    }

    public void GameClearProcess()
    {
        remainBallText.text = $"���� �� �� : {GameManager.Instance.sphereAddForce.ball - 1}";
    }
}
