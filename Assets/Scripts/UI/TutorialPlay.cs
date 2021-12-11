using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPlay : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    private void Awake()
    {
        yesButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(true);

            SceneManager.LoadScene("Tutorial");
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
        });

        noButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);

            GameManager.Instance.isTutorialPlay = true;
        });
    }
}
