using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterAudioSlider;
    public Slider bgmAudioSlider;
    public Slider effectAudioSlider;


    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void AudioMasterControl()
    {
        float sound = masterAudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Master", -80);
        }
        else
        {
            masterMixer.SetFloat("Master", sound);
        }
    }

    public void AudioBGMControl()
    {
        float sound = bgmAudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }

    public void AudioEffectControl()
    {
        float sound = effectAudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Effect", -80);
        }
        else
        {
            masterMixer.SetFloat("Effect", sound);
        }
    }
}
