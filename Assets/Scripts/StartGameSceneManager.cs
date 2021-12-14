using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSceneManager : MonoBehaviour
{
    public Button startButton = null;
    public Button settingButton = null;

    public GameObject settingPanel = null;

    public GameEnd gameEnd;
    
    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene");
        });

        settingButton.onClick.AddListener(() =>
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        });
    }

    private void Update()
    {
        GameManager.CheckEscape(gameEnd);
    }
}
