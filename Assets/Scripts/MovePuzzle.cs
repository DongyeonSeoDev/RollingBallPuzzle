using UnityEngine;
using DG.Tweening;

public class MovePuzzle : MonoBehaviour
{
    [SerializeField] private Vector3[] nextPositions = null;
    [SerializeField] private float[] speeds = null;

    private bool isMove = false;
    private bool isPause = false;
    private int currentPosition = 0;

    private void Start()
    {
        transform.DOMove(nextPositions[currentPosition], 0.01f);
        transform.position = nextPositions[currentPosition];
    }

    private void Update()
    {
        if (!isMove && !isPause)
        {
            currentPosition = (currentPosition + 1) % nextPositions.Length;
            isMove = true;

            transform.DOMove(nextPositions[currentPosition], speeds[currentPosition])
                .SetEase(Ease.Linear)
                .SetUpdate(UpdateType.Fixed)
                .OnComplete(() =>
                {
                    isMove = false;
                });
        }
    }
}
