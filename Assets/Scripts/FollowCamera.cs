using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float basicsSpeed;

    private GameObject followObject;

    private float speed = 0f;
    private float distance = 0f;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager가 없습니다.");
            Debug.LogWarning("게임은 StartGameScene에서 시작해야 합니다.");

            SceneManager.LoadScene("StartGameScene");

            return;
        }
    }

    private void Start()
    {
        followObject = GameManager.Instance.ball;
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, followObject.transform.position);

        if (distance > 25)
        {
            speed = basicsSpeed + 1;
        }
        else if (distance > 20)
        {
            speed = basicsSpeed;
        }
        else
        {
            speed = basicsSpeed - 1;
        }

        transform.position = Vector3.Lerp(transform.position, followObject.transform.position + offset, speed * Time.fixedDeltaTime);
    }
}
