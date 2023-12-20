using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider MasteraudioSlider;
    public Slider BGMaudioSlider;
    public Slider EffectaudioSlider;

    public void MasterAudioControl()
    {
        float sound = MasteraudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Master", -80);
        }
        else
        {
            masterMixer.SetFloat("Master", sound);
        }
    }

    public void BGMAudioControl()
    {
        float sound = BGMaudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }

    public void EffectAudioControl()
    {
        float sound = EffectaudioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Effect", -80);
        }
        else
        {
            masterMixer.SetFloat("Effect", sound);
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}