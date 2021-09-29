using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            Debug.Log("instance가 이미 있습니다.");
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetScene();
        }
    }

    public static void SetBallText(string text)
    {
        instance.ballText.text = text;
    }

    public static void GameOver()
    {
        instance.gameOverPanel.SetActive(true);
        instance.Invoke("ResetScene", 3f);
    }

    public static void GameClear()
    {
        instance.gameClearPanel.SetActive(true);
        instance.Invoke("ResetScene", 3f);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
