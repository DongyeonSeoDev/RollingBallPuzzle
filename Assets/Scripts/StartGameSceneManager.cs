using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSceneManager : MonoBehaviour
{
    public Button startButton = null;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene");
        });
    }
}
