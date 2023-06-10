using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    private ParticleSystem.EmissionModule ParticleEmission;
    public GameObject ObjectWithPartSys;
    private void Awake()
    {
        if (ObjectWithPartSys != null)
        {
            ObjectWithPartSys.GetComponent<ParticleSystem>().Play();
            //ThisParticleSystem.Play();
            ParticleEmission = ObjectWithPartSys.GetComponent<ParticleSystem>().emission;
        }
    }

    public void SetEmissionActive()
    {
        if (ObjectWithPartSys != null)
            ParticleEmission.enabled = true;
    }
}
//GetComponent<ParticleSystem>().Play();
//em = GetComponent<ParticleSystem>().emission;