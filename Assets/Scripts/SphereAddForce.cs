using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereAddForce : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;

    private Vector3 startMousePosition = Vector3.zero;
    private Vector3 endMousePosition = Vector3.zero;
    private Vector3 startPosition;
    private Vector3 force;
    private Vector3 startCameraPosition;

    private Rigidbody myRigidbody = null;

    private MeshRenderer mr = null;
    private SphereCollider sc = null;

    private float timeSpeed = 0f;
    private float speed = 0f;
    public int ball = 20;
    public int clearCount = 9;
    private int puzzleCount = 0;
    private bool isReset = false;
    private bool isclick = false;
    private bool isGround = true;
    private float clickTime = 0f;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
        startPosition = transform.position;
        startCameraPosition = Camera.main.transform.position;
    }

    private void Update()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, 1f, whatIsGround);

        if (transform.position.y < -30f)
        {
            ResetPlayer();
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            startMousePosition = Input.mousePosition;
            isclick = true;
            clickTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (!isclick)
            {
                return;
            }

            endMousePosition = Input.mousePosition;

            if (Vector3.Distance(startMousePosition, endMousePosition) >= 3f && isGround)
            {
                timeSpeed = Mathf.Clamp(1 - (Time.time - clickTime) / 2, 0f, 1f);
                speed = Mathf.Clamp(Vector3.Distance(startMousePosition, endMousePosition) / 20f * timeSpeed, 3f, 50f);
                force = (new Vector3(endMousePosition.x, 0f, endMousePosition.y) - new Vector3(startMousePosition.x, 0f, startMousePosition.y)).normalized;

                myRigidbody.AddForce( force * -speed, ForceMode.Impulse);
            }
        }
    }

    public void hiddenResetPlayer()
    {
        if (isReset)
        {
            return;
        }

        mr.enabled = false;
        sc.enabled = false;
        myRigidbody.isKinematic = true;

        puzzleCount++;

        if (puzzleCount >= clearCount)
        {
            GameManager.GameClear();
            return;
        }

        ResetPlayer(1f);
    }

    public void ResetPlayer(float delay = 0f)
    {
        if (isReset)
        {
            return;
        }

        isReset = true;
        startMousePosition = Vector3.zero;
        endMousePosition = Vector3.zero;

        if (delay <= 0)
        {
            ResetStart();
        }
        else
        {
            Invoke("ResetStart", delay);
        }
    }

    private void ResetStart()
    {
        if (!mr.enabled)
        {
            mr.enabled = true;
        }

        if (!sc.enabled)
        {
            sc.enabled = true;
        }

        if (myRigidbody.isKinematic)
        {
            myRigidbody.isKinematic = false;
        }

        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;
        Camera.main.transform.position = startCameraPosition;

        isReset = false;
        isclick = false;

        ball--;
        UIManager.SetBallText(ball.ToString("00"));

        if (ball <= 0)
        {
            UIManager.GameOver();
        }
    }
}
