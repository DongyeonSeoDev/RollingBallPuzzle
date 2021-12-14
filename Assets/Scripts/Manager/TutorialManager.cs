using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public Text text;
    public string[] texts;
    private int textCount;

    public GameObject nextObject;
    public GameObject cover;
    public GameObject pauseUI;
    public GameObject remainUI;
    public GameObject resetUI;
    public RectTransform arrow;

    private bool isClickNext;

    [HideInInspector]
    public bool isMove;

    private Tween tween;

    private bool IsClickNext
    {
        get
        {
            return isClickNext;
        }

        set
        {
            isClickNext = value;
            nextObject.SetActive(isClickNext);
        }
    }

    private void Start()
    {
        GameManager.Instance.tutorial = this;

        Invoke("TutorialStart", 2f);
    }

    private void Update()
    {
        if (IsClickNext && Input.GetMouseButtonDown(0))
        {
            TextChange();

            IsClickNext = false;

            switch (textCount)
            {
                case 2:
                    ShowRemainUI();
                    break;
                case 3:
                    ShowResetUI();
                    break;
                case 4:
                    BallMove();
                    break;
                case 5:
                    EndArrowMove();
                    break;
                case 7:
                case 8:
                    IsClickNext = true;
                    break;
                case 9:
                    GameManager.Instance.tutorial = null;
                    GameManager.Instance.isTutorialPlay = true;
                    GameManager.Save();
                    SceneManager.LoadScene("StartScene");
                    break;
            }
        }
    }

    public void TutorialStart()
    {
        TextChange();
        ShowPauseUI();

        IsClickNext = true;
    }

    private void TextChange()
    {
        textCount = (textCount + 1) % texts.Length;
        text.text = texts[textCount];
    }

    private void ShowPauseUI()
    {
        cover.SetActive(true);
        pauseUI.SetActive(true);
    }

    private void ShowRemainUI()
    {
        pauseUI.SetActive(false);
        remainUI.SetActive(true);

        IsClickNext = true;
    }

    private void ShowResetUI()
    {
        remainUI.SetActive(false);
        resetUI.SetActive(true);

        IsClickNext = true;
    }

    public void BallMove()
    {
        resetUI.SetActive(false);
        cover.SetActive(false);

        ArrowMove();
    }

    public void ArrowMove()
    {
        arrow.gameObject.SetActive(true);
        tween = arrow.DOAnchorPosY(350f, 0.7f).SetRelative().SetLoops(-1, LoopType.Yoyo);

        isMove = true;
        IsClickNext = true;
    }
    
    private void EndArrowMove()
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill();
        }

        arrow.gameObject.SetActive(false);
    }

    public void FillBlock()
    {
        TextChange();
        IsClickNext = true;
    }
}