using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAddForce : MonoBehaviour
{
    private Vector3 startMousePosition = Vector3.zero;
    private Vector3 endMousePosition = Vector3.zero;
    private Vector3 startPosition;
    private Vector3 cameraStartPosition;

    private Rigidbody myRigidbody = null;

    private MeshRenderer mr = null;
    private SphereCollider sc = null;

    public float speed = 10f;

    private bool isMove = false;
    private bool isReset = false;
    private bool isclick = false;
    private float time = 0f;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
        startPosition = transform.position;
        cameraStartPosition = Camera.main.transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -50 || (time != 0 && time + 10 <= Time.time))
        {
            ResetPlayer();
        }

        if (isMove)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
            isclick = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!isclick)
            {
                return;
            }

            endMousePosition = Input.mousePosition;

            if (Vector3.Distance(startMousePosition, endMousePosition) >= 3f)
            {
                speed = Mathf.Clamp(Vector3.Distance(startMousePosition, endMousePosition) / 5f, 3f, 70f);

                myRigidbody.AddForce(transform.forward * -speed, ForceMode.Impulse);
                isMove = true;
                time = Time.time;
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
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        if (isReset)
        {
            return;
        }

        isReset = true;
        time = 0;
        startMousePosition = Vector3.zero;
        endMousePosition = Vector3.zero;

        Invoke("ResetStart", 3f);
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

        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;

        Camera.main.transform.position = cameraStartPosition;
        isMove = false;
        isReset = false;
        isclick = false;
    }
}
