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

    //Clip1: Footstep -
    //Clip2: Candy pickup -
    //Clip3: Candyrush -
    //Clip4: Chest opens -
    //Clip5: Player in enemy fov
    //Clip6: Key pickup -
    //Clip7: Destroyed object
}

