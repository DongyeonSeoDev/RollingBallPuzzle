using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    private bool isShow = false;

    private void Awake()
    {
        yesButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        noButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            isShow = !isShow;
        });
    }

    public void ChangeUI()
    {
        isShow = !isShow;
        gameObject.SetActive(isShow);
    }
}
