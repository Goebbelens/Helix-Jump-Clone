using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerVolume : MonoBehaviour
{
    [Min(0)]
    public float Volume = 1f;
    void Update()
    {
        AudioListener.volume = Volume;
    }
}
