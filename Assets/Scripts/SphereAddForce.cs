using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAddForce : MonoBehaviour
{
    private Vector3 startMousePosition = Vector3.zero;
    private Vector3 endMousePosition = Vector3.zero;
    private Vector3 startPosition;
    private Vector3 cameraStartPosition;
    private Vector3 force;

    private Rigidbody myRigidbody = null;

    private MeshRenderer mr = null;
    private SphereCollider sc = null;

    private float timeSpeed = 0f;
    private float speed = 0f;
    private bool isReset = false;
    private bool isclick = false;
    private float time = 0f;
    private float clickTime = 0f;

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

        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
            isclick = true;
            clickTime = Time.time;
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
                timeSpeed = Mathf.Clamp(1 - (Time.time - clickTime) / 2, 0f, 1f);
                speed = Mathf.Clamp(Vector3.Distance(startMousePosition, endMousePosition) / 20f * timeSpeed, 3f, 3000f);
                force = (new Vector3(endMousePosition.x, 0f, endMousePosition.y) - new Vector3(startMousePosition.x, 0f, startMousePosition.y)).normalized;

                if (-0.2f <= force.x && force.x <= 0.2f)
                {
                    force.x = 0f;
                }
                else if (-0.4f <= force.x)
                {
                    force.x = 0.05f;
                }
                else if (force.x <= 0.4f)
                {
                    force.x = -0.05f;
                }
                else
                {
                    force.x = force.x > 0 ? force.x - 0.35f : force.x + 0.35f;
                }

                myRigidbody.AddForce( force * -speed, ForceMode.Impulse);
                
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
        isReset = false;
        isclick = false;
    }
}
