using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSceneManager : MonoBehaviour
{
    public Button startButton = null;
    public Button settingButton = null;

    public GameObject settingPanel = null;
    
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
}
