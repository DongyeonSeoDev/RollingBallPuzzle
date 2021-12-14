using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    public static UIManager instance = null;

    public Text ballText = null;
    public Button resetButton = null;
    public Button pauseButton = null;

    public GameOver gameOver = null;
    public GameClear gameClear = null;

    public GameObject pauseUI = null;
    public GameObject settingUI = null;

    public  static bool isPause = false;
    public static bool isSetting = false;

    protected override void Awake()
    {
        base.Awake();

        if (instance != null)
        {
            Debug.Log("instance가 이미 있습니다.");
            Destroy(this);

            return;
        }

        instance = this;

        GameManager.Instance.GameStart();
    }

    private void Start()
    {
        resetButton.onClick.AddListener(() =>
        {
            GameManager.Instance.BallOut();
        });

        pauseButton.onClick.AddListener(() =>
        {
            Paues();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paues();
        }
    }

    public static void Paues()
    {
        isPause = !isPause;

        Time.timeScale = isPause ? 0 : 1;
        Instance.pauseUI.SetActive(isPause);
    }

    public static void SetBallText(string text)
    {
        instance.ballText.text = text;
    }

    public static void GameOver()
    {
        instance.gameOver.gameObject.SetActive(true);
        instance.gameOver.GameOverProcess();
    }

    public static void GameClear()
    {
        instance.gameClear.gameObject.SetActive(true);
        instance.gameClear.GameClearProcess();
    }

    public static void ResetScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("StartScene");

        if (GameManager.Instance.tutorial != null)
        {
            GameManager.Instance.tutorial = null;
        }
    }

    public static void ReStartScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }

    public static void Setting()
    {
        isSetting = !isSetting;

        Instance.settingUI.SetActive(isSetting);
    }
}
