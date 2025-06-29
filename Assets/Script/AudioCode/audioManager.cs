using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgorundPref = "BackgorundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    public int firstPayInt;
    public Slider backgroundSlider, soundeffectsSlider;
    private float backgroundFloat, soundeffectsSfloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundeffectAudio; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPayInt == 0)
        {
            backgroundFloat = .125f;
            soundeffectsSfloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundeffectsSlider.value = soundeffectsSfloat;
            PlayerPrefs.SetFloat(BackgorundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundeffectsSfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
           backgroundFloat = PlayerPrefs.GetFloat(BackgorundPref);
           backgroundSlider.value =backgroundFloat;
           soundeffectsSfloat = PlayerPrefs.GetFloat(SoundEffectPref);
           soundeffectsSlider.value = soundeffectsSfloat;
        }
    }
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgorundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundeffectsSlider.value);

    }
    private void OnApplicationFocus(bool infocus)
    {

        if (!infocus)
        {
            SaveSoundSettings();
        }

    }

}
