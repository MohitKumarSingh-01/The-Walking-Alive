using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
 
public class AudioManager : MonoBehaviour {
 
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
     
    void Start () 
    {
         //load from sound music slider
         audioMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume", 0));
         audioMixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("sfxVolume", 0));
    }
 
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
    public void SetSfxVolume (float volume)
    {
        audioMixer.SetFloat("sfxVolume", volume);
    }
}