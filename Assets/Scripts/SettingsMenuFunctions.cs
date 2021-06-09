using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuFunctions : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);


    }
}
