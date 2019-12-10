using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffsetter : MonoBehaviour
{

    [SerializeField]
    private bool isOn = true;

    [SerializeField]
    private float maxOffset = 0.5f;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform pillarTransform;

    [SerializeField]
    private Transform cameraTransform;

    private float maxDistance;
    private float cameraDistance;
    void Start()
    {
        maxDistance = Mathf.Abs(playerTransform.position.x - pillarTransform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            cameraDistance = Mathf.Abs(cameraTransform.position.x - pillarTransform.position.x);
            float amplitude = 1 - Mathf.Min(1, cameraDistance / maxDistance); // 0 when far 1 when close
            playerTransform.position = new Vector3(0, 0, maxOffset * amplitude);
        }
    }
}
