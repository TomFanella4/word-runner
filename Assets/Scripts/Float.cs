using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveDistance;
    public float moveSpeed;
    public Vector3 rotateDirection;
    public float rotateDistance;
    public float rotateSpeed;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = startPosition + moveDirection * moveDistance * Mathf.Sin(Time.fixedTime * moveSpeed);
        transform.rotation = Quaternion.Euler(rotateDirection.x, rotateDirection.y * rotateDistance * Mathf.Sin(Time.fixedTime * rotateSpeed), rotateDirection.z);
    }
}
