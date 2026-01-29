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

    //Element0: Footstep -
    //Element1: Candy pickup -
    //Element2: Candyrush -
    //Element3: Chest opens -
    //Element4: Player in enemy fov - 
    //Element5: Key pickup -
    //Element6: Destroyed object
}

