using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool isMusicMute = false,
        isSfxMute = false;

    public float LastMusicVolume,
        LastSfxVolume;

    private void Start()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 1f));
        SetSfxVolume(PlayerPrefs.GetFloat("SfxVolume", 1f));
        DontDestroyOnLoad(gameObject);
    }

    public void MuteMusic()
    {
        isMusicMute = !isMusicMute;
        if (isMusicMute) LastMusicVolume = GetMusicVolume();
        // SetMusicVolume(isMusicMute ? 0.001f : 1f);
        Debug.Log("/*M*/  " + GetMusicVolume());

        SetMusicVolume(isMusicMute ? 0.001f : LastMusicVolume);
    }

    public void MuteSfx()
    {
        isSfxMute = !isSfxMute;
        //if (isSfxMute) audioMixer.GetFloat("SfxVolume", out LastSfxVolume);
        if (isSfxMute) LastSfxVolume = GetSfxVolume();
        //SetSfxVolume(isSfxMute ? 0.001f : 1f);
        Debug.Log("/*M*/  " + GetSfxVolume());
        SetSfxVolume(isSfxMute ? 0.001f : LastSfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log("SetMusicVolume: " +Mathf.Log(volume) * 20);
        audioMixer.SetFloat("MusicVolume", Mathf.Log(volume) * 20);
        // audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSfxVolume(float volume)
    {
        Debug.Log("SetSfxVolume: " +Mathf.Log(volume) * 20);
        audioMixer.SetFloat("SfxVolume", Mathf.Log(volume) * 20);
        // audioMixer.SetFloat("SfxVolume", volume);
    }

    public float GetMusicVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float volume);
        return Mathf.Exp(volume / 20);
    }

    public float GetSfxVolume()
    {
        audioMixer.GetFloat("SfxVolume", out float volume);
        return Mathf.Exp(volume / 20);
    }
}
