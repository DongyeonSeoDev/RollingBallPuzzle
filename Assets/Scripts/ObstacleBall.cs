using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBall : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float limitY;

    private float currentTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((transform.position.y <= limitY))
        {
            RemoveObject();
        }

        currentTime += Time.deltaTime;
    }

    public void RemoveObject()
    {
        gameObject.SetActive(false);
    }

    public void ResetObject(Vector3 resetPosition, float powerY, float powerZ)
    {
        gameObject.SetActive(true);

        transform.position = resetPosition;
        transform.rotation = Quaternion.identity;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        currentTime = 0f;

        Move(powerY, powerZ);
    }

    private void Move(float powerY, float powerZ)
    {
        rb.AddForce(Random.Range(-70f, 70f), powerY, powerZ, ForceMode.Impulse);
    }
}
