using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource SoundFXObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip clip,Transform SpawnTransform,float Volume)
    {
        //Spawn in the gameobject
        AudioSource audiosource = Instantiate(SoundFXObject, SpawnTransform.position, Quaternion.identity);

        //Assign the audio clip
        audiosource.clip = clip;

        //Assign the volume
        audiosource.volume = Volume;

        //Play the audio
        audiosource.Play();

        //get lenght of the audio clip
        float clipLength = audiosource.clip.length;

        //Destroy the audio source after it finishes playing
        Destroy(audiosource.gameObject, clipLength);
    }
}
