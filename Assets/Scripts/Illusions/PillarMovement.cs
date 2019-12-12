using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField]
    private bool rotated = false;
    [SerializeField]
    private float rotateSpeed = 0.1f;
    [SerializeField]
    private float rotatedAngle = 5f;

    [Header("Movement")]
    [SerializeField]
    private bool moved = false;
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private Vector3 movedDistance;

    private Vector3 originPos;
    private Vector3 originAngle;

    [SerializeField]
    private Transform pillarTransform;

    [SerializeField]
    private Transform playerTransform;

    private void Start()
    {
        originPos = transform.position;
        originAngle = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Rotate();
        }
    }

    public void Move()
    {
        //StopAllCoroutines();
        moved = !moved;
        StartCoroutine(Moving());
    }
    public IEnumerator Moving()
    {
        Vector3 currentPos = transform.position;
        Vector3 destPos = originPos;

        if (moved)
        {
            destPos.z += movedDistance.z;
            destPos.x += movedDistance.x;
        }


        while ( Vector3.Distance(currentPos, destPos) > 0.01f)
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
        //Vector3 dist = playerTransform.position - transform.position;
        //dist.y = 0;
        //transform.Translate(-dist);
        //pillarTransform.Translate(dist);
        rotated = !rotated;
        //originPos = transform.position;


        StartCoroutine(Rotating());
    }
    public IEnumerator Rotating()
    {
        Vector3 currentAngle = transform.rotation.eulerAngles;
        Vector3 destAngle = originAngle;

        if (rotated)
        {
            destAngle.y += rotatedAngle;
        }

        while (Mathf.Abs(currentAngle.y - destAngle.y) > 0.01f)
        {
            currentAngle = Vector3.Lerp(currentAngle, destAngle, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(currentAngle);
            yield return new WaitForFixedUpdate();
        }
        currentAngle = destAngle;
        transform.rotation = Quaternion.Euler(currentAngle);
    }
}
