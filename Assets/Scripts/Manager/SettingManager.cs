using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Sprite[] soundButtonSprites = null;
    public Button soundButton = null;
    public Button closeButton = null;
    public Button tutorialButton = null;

    public Sound sound = null;

    private bool isMute;

    private void Awake()
    {
        soundButton.onClick.AddListener(() =>
        {
            isMute = !GameManager.Instance.isMute;
            soundButton.image.sprite = isMute ? soundButtonSprites[0] : soundButtonSprites[1];

            GameManager.Instance.isMute = isMute;

            sound?.SoundVolumeChange();
        });

        closeButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });

        tutorialButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Tutorial");
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
        });
    }
}
