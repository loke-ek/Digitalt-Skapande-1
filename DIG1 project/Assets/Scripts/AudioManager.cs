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


    //Element1: Candy pickup -
    //Element2: Candyrush -
    //Element4: Player in enemy fov - 
     
    //-------Completed--------
    //Element0: Footstep
    //Element3: Chest opens
    //Element5: Key pickup 
    //Element6: Destroyed object 
}

