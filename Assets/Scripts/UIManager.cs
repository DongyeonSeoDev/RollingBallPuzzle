using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Text ballText = null;
    public GameObject gameOverPanel = null;
    public GameObject gameClearPanel = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("instance�� �̹� �ֽ��ϴ�.");
        }
        else
        {
            instance = this;
        }
    }

    public static void SetBallText(string text)
    {
        instance.ballText.text = text;
    }

    public static void GameOver()
    {
        instance.gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public static void GameClear()
    {
        instance.gameClearPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
