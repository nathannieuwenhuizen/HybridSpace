using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffsetter : MonoBehaviour
{

    [SerializeField]
    private bool isOn = true;

    [SerializeField]
    private float amplitude = 0.5f;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            isOn = !isOn;
        }
        if (isOn)
        {
            cameraDistance = Mathf.Abs(cameraTransform.localPosition.x - pillarTransform.position.x);
            float value = 1 - Mathf.Min(1, cameraDistance / maxDistance); // 0 when far 1 when close
            Debug.Log("value: " + value + " | camera distance: " + cameraDistance + " | cmaera pos: " + cameraTransform.localPosition.x );
            playerTransform.position = new Vector3(0, 0, amplitude * value);
        }
    }
}
