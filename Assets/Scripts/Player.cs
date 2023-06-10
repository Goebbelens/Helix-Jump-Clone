using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float BounceStrength = 1f;
    public Game Game;
    public int Score = 0;
    public Platform CurrentPlatform;
    public PlaySound PlaySound;
    public ActivateParticles ActivateParticles;

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceStrength, 0);
        PlaySound.PlayCurrentSound();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Destroy(Rigidbody);
        //Rigidbody.velocity = Vector3.zero;
        //Rigidbody.isKinematic = true;
        ActivateParticles.SetEmissionActive();
    }

    public void AddScore()
    {
        Score++;
    }
}
