using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    [SerializeField] protected Vector3[] nextPositions = null;
    [SerializeField] protected float[] speeds = null;

    protected bool isMove = false;
    protected bool isPause = false;
    protected int currentPosition = 0;

    protected virtual void Start()
    {
        transform.DOMove(nextPositions[currentPosition], 0.01f);
        transform.position = nextPositions[currentPosition];
    }

    protected virtual void Update()
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
