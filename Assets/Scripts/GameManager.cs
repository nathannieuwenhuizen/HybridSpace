using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource backgroundAudioSource;

    [SerializeField]
    private ParticleSystem insidePillarParticles;

    [SerializeField]
    private Material insideMaterialSkybox;

    private bool inPillar = false;

    [SerializeField]
    private float milkywayRotationSpeed = 0.1f;

    private float milkyWayRotation;
    // Start is called before the first frame update
    void Start()
    {
        insidePillarParticles.transform.localScale = new Vector3(0, 0, 0);
        Camera.main.clearFlags = CameraClearFlags.SolidColor;

    }

    public void OnPillarEnter()
    {
        inPillar = true;
        backgroundAudioSource.pitch = 1.5f;
        insidePillarParticles.transform.localScale = new Vector3(1,1,1);

        RenderSettings.skybox = insideMaterialSkybox;
        Camera.main.clearFlags = CameraClearFlags.Skybox;
    }

    public void OnPillarExit()
    {
        inPillar = false;
        backgroundAudioSource.pitch = 1.0f;
        insidePillarParticles.transform.localScale = new Vector3(0, 0, 0);

        Camera.main.clearFlags = CameraClearFlags.SolidColor;

    }
    private void Update()
    {
        if (inPillar)
        {
            milkyWayRotation = (milkyWayRotation + milkywayRotationSpeed) % 360;

            //insideMaterialSkybox.SetFloat("Rotation", milkyWayRotation);
            insideMaterialSkybox.SetFloat("_Rotation", milkyWayRotation);
        }
    }
}
