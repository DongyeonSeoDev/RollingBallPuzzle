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
        remainBallText.text = $"남은 공 수 : {GameManager.Instance.sphereAddForce.ball - 1}";
    }
}
