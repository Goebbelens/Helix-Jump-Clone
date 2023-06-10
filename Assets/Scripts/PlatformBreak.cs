using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    public Sector[] Sectors;
    public float DistanceForward;
    public float DistanceUp;
    public float FadeSpeed;
    public int BrokenPlatfromsCount = 0;
    public PlaySound PlaySound;

    private void OnTriggerExit()
    {
        foreach(Sector e in Sectors)
        {
            e.SectorBurst(DistanceForward, DistanceUp, FadeSpeed);
        }
        AddScore();
        PlaySound.PlayCurrentSound();
    }

    public void AddScore()
    {
        BrokenPlatfromsCount++;
    }
}
