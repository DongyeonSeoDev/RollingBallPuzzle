using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSceneManager : MonoBehaviour
{
    public Button startButton = null;
    public Button soundButton = null;

    public Sprite[] soundButtonSprites = null;

    private bool isMute;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene");
        });

        soundButton.onClick.AddListener(() =>
        {
            isMute = !GameManager.Instance.isMute;
            soundButton.image.sprite = isMute ? soundButtonSprites[0] : soundButtonSprites[1];

            GameManager.Instance.isMute = isMute;
        });
    }
}
