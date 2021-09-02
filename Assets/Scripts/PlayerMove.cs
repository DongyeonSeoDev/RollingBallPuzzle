using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform shphere = null;
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        Vector3 lerpTransform = Vector3.Lerp(transform.position, new Vector3(shphere.position.x, shphere.position.y, shphere.position.z + 5), speed * Time.deltaTime);
        lerpTransform.x = transform.position.x;
        lerpTransform.y = transform.position.y;
        transform.position = lerpTransform;
    }
}
