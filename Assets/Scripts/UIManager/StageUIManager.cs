using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageUIManager : MonoBehaviour
{
    public RectTransform stagePanelPosition;
    public Button nextButton;
    public Sprite[] nextButtonSprite;

    private bool isStageChange = false;

    private void Awake()
    {
        nextButton.onClick.AddListener(() =>
        {
            stagePanelPosition.DOAnchorPosX(isStageChange ? 0 : -2000, 0.5f);
            nextButton.image.sprite = nextButtonSprite[isStageChange ? 0 : 1];
            isStageChange = !isStageChange;
        });
    }
}
