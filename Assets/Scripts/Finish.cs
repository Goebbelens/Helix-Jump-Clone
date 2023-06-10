using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private ParticleSystem.EmissionModule em;
    public ActivateParticles ActivateParticles;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            player.ReachFinish();
            ActivateParticles.SetEmissionActive();
        }
    }
}
