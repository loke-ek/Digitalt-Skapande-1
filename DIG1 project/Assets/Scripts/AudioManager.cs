using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSources;
    [SerializeField] List<AudioClip> audioClips;

    public void PlaySound(int clipNumber)
    {

        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                source.clip = audioClips[clipNumber];
                source.Play();
                return;
            }
        }

    }

    //Clip1: Footstep
    //Clip2: Dash
    //Clip3: ItemPickup
    //Clip4: Candyrush
    //Clip5: Chest opens/destroyable objects
}

