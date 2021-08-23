using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : BasePanel
{
    // Start is called before the first frame update
    public Slider musicSlider;
    public Slider sfxSlider;
    private bool _blockToggleListener;
    private float currMusicVol, currSfxVol;
    void Start()
    {
        

        currMusicVol = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        currSfxVol = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
        Debug.Log("curr Music: " + currMusicVol+" || " +currSfxVol);
        sfxSlider.value = currSfxVol;
        musicSlider.value = currMusicVol;
        // musicToggle.onValueChanged.AddListener( () => {
        //     currMusicVol = musicSlider.value;
        //     musicSlider.value = musicSlider.minValue;
        // } );
        
        // sfxToggle.onValueChanged.AddListener(() =>
        // {
        //     currSfxVol = sfxSlider.value;
        //     sfxSlider.value = sfxSlider.minValue;
        // } );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SfxSliderValueChanged(float volume)
    {
        // bool isOn = !(Mathf.Approximately(sfxSlider.minValue, volume));
        // if (sfxToggle.isOn != isOn)
        // {
        //     _blockToggleListener = true;
        //     sfxToggle.isOn = isOn;
        // }
        // GlobalManager.Instance.musicController.SetSfxVolume(isOn ? volume : 0.001f);
        

        // Debug.Log("SfxSliderValueChanged: " + sfxSlider.value );
        GlobalManager.Instance.musicController.SetSfxVolume(sfxSlider.value);
        volume = sfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    public void MusicSliderValueChanged(float volume)
    {
        // bool isOn = !(Mathf.Approximately(musicSlider.minValue, volume));
        // if (musicToggle.isOn != isOn)
        // {
        //     _blockToggleListener = true;
        //     musicToggle.isOn = isOn;
        // }
        // GlobalManager.Instance.musicController.SetMusicVolume(isOn ? volume : 0.001f);
        
        // Debug.Log("MusicSliderValueChanged: " + musicSlider.value);
        GlobalManager.Instance.musicController.SetMusicVolume(musicSlider.value);
        volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

}
