using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource backgroundAudioSource;

    [SerializeField]
    private ParticleSystem insidePillarParticles;

    private bool inPillar = false;

    // Start is called before the first frame update
    void Start()
    {
        insidePillarParticles.transform.localScale = new Vector3(0, 0, 0);

    }

    public void OnPillarEnter()
    {
        inPillar = true;
        backgroundAudioSource.pitch = 1.5f;
        insidePillarParticles.transform.localScale = new Vector3(1,1,1);
    }

    public void OnPillarExit()
    {
        inPillar = false;
        backgroundAudioSource.pitch = 1.0f;
        insidePillarParticles.transform.localScale = new Vector3(0, 0, 0);
    }
}
