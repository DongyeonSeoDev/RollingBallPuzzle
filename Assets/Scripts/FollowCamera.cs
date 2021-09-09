using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float basicsSpeed;

    private float speed = 0f;
    private float distance = 0f;

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
