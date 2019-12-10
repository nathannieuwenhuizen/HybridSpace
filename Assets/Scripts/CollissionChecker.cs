using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollissionChecker : MonoBehaviour
{
    [SerializeField]
    private UnityEvent inPillarEvent;

    [SerializeField]
    private UnityEvent outPillarEvent;

    [SerializeField]
    private Color insideColor;
    private Color outSideColor;

    private MeshRenderer mf;

    // Start is called before the first frame update
    void Start()
    {
        mf = GetComponent<MeshRenderer>();
        outSideColor = Camera.main.backgroundColor;

        if (inPillarEvent == null)
            inPillarEvent = new UnityEvent();

        if (outPillarEvent == null)
            outPillarEvent = new UnityEvent();

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collission! " + other.name);
        //Debug.Log(Camera.main.name);
        if (other.tag == "MainCamera")
        {
            inPillarEvent.Invoke();

            mf.enabled = false;
            Camera.main.backgroundColor = insideColor;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            outPillarEvent.Invoke();

            mf.enabled = true;
            Camera.main.backgroundColor = outSideColor;
        }
    }
}
