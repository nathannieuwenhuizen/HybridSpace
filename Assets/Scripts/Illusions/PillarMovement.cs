using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    [Header("Rotation")]
    private bool rotated = false;
    [SerializeField]
    private float rotateSpeed = 0.1f;
    [SerializeField]
    private float rotatedAngle = 5f;

    [Header("Rotation")]
    private bool moved = false;
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float moveDistance = 0.5f;

    private Vector3 originPos;

    [SerializeField]
    private Transform pillarTransform;

    [SerializeField]
    private Transform playerTransform;

    private void Start()
    {
        originPos = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !moved)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.R) && !rotated)
        {
            Rotate();
        }
    }

    public void Move()
    {
        StartCoroutine(Moving());
    }
    public IEnumerator Moving()
    {
        Vector3 currentPos = originPos;
        Vector3 destPos = originPos;
        destPos.z += moveDistance;
        while(Mathf.Abs(originPos.z - destPos.z) > 0.01f)
        {
            currentPos = Vector3.Lerp(currentPos, destPos, Time.deltaTime * moveSpeed);
            transform.position = currentPos;
            yield return new WaitForFixedUpdate();
        }
        currentPos = destPos;
        transform.position = currentPos;
    }

    public void Rotate()
    {
        Vector3 dist = playerTransform.position - transform.position;
        dist.y = 0;
        transform.Translate(-dist);
        pillarTransform.Translate(dist);

        originPos = transform.position;


        StartCoroutine(Rotating());
    }
    public IEnumerator Rotating()
    {
        Vector3 currentAngle = transform.rotation.eulerAngles;
        Vector3 destAngle = transform.rotation.eulerAngles;
        destAngle.y += rotatedAngle;
        while (Mathf.Abs(originPos.y - destAngle.y) > 0.01f)
        {
            currentAngle = Vector3.Lerp(currentAngle, destAngle, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(currentAngle);
            yield return new WaitForFixedUpdate();
        }
        currentAngle = destAngle;
        transform.rotation = Quaternion.Euler(currentAngle);
    }
}
