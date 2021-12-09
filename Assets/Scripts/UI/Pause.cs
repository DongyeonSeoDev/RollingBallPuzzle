using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button continueButton;
    public Button settingButton;
    public Button reStartButton;
    public Button exitButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            UIManager.Paues();
        });

        settingButton.onClick.AddListener(() =>
        {
            UIManager.Setting();
        });

        reStartButton.onClick.AddListener(() =>
        {
            UIManager.Paues();
            UIManager.ReStartScene();
        });

        exitButton.onClick.AddListener(() =>
        {
            UIManager.Paues();
            UIManager.ResetScene();
        });
    }
}
