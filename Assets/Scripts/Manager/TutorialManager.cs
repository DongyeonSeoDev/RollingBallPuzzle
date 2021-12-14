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
                    ShowResetUI();
                    break;
                case 3:
                    BallMove();
                    break;
                case 4:
                    EndArrowMove();
                    break;
                case 6:
                case 7:
                    IsClickNext = true;
                    break;
                case 8:
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
        ShowRemainUI();

        IsClickNext = true;
    }

    private void TextChange()
    {
        textCount = (textCount + 1) % texts.Length;
        text.text = texts[textCount];
    }

    private void ShowRemainUI()
    {
        cover.SetActive(true);
        remainUI.SetActive(true);
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