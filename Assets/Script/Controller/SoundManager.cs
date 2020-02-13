using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

// -------------------------
// Menu Controller:
// - Controls the music & effect
// TODO: Load music w/ async
// TODO: Play music w/ enums
// TODO: Mute & Unmute
// -------------------------
public class SoundManager : MonobehaviorSingleton<SoundManager>
{
    public static SoundManager instance;
    public AudioFile[] audioFiles;

    private float timeToReset;

    private bool timerIsSet = false;

    private Music tmpName;

    private float tmpVol;

    private bool isLowered = false;

    private bool fadeOut = false;

    private bool fadeIn = false;

    private string fadeInUsedString;

    private string fadeOutUsedString;
    // Start is called before the first frame update
    void Start()
    {
        audioFiles = new AudioFile[100];
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in audioFiles)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.loop = s.isLooping;
            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    // Update is called once per frame
    private void Update()
	{
		if (Time.time >= timeToReset && timerIsSet)
		{
			ResetVol();
			timerIsSet = false;
		}
	}

    #region METHODS


    public static void PlayMusic(Music audioId)
    {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioID == audioId);
        if (s == null)
        {
            Debug.LogError("Sound name" + audioId + "not found!");
            return;
        }
        else
        {
            if (s.source.isPlaying)
            {
                Debug.LogWarning($"Requested Audio File {audioId} is already Playing");
            }
            else
            {
                s.source.Play();
            }
        }
    }

    public static void PauseMusic(Music audioId)
	{
		AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioID == audioId);
		if (s == null)
		{
			Debug.LogError("Sound name" + audioId + "not found!");
			return;
		}
		else
		{
			s.source.Pause();
		}
	}

    public static void UnPauseMusic(Music audioId)
	{
		AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioID == audioId);
		if (s == null)
		{
			Debug.LogError("Sound name" + audioId + "not found!");
			return;
		}
		else
		{
			s.source.UnPause();
		}
	}

    public static void LowerVolume(Music audioId, float _duration)
	{
		if (instance.isLowered == false)
		{
			AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioID == audioId);
			if (s == null)
			{
				Debug.LogError("Sound name" + audioId + "not found!");
				return;
			}
			else
			{
				instance.tmpName = audioId;
				instance.tmpVol = s.volume;
				instance.timeToReset = Time.time + _duration;
				instance.timerIsSet = true;
				s.source.volume = s.source.volume / 3;
			}

			instance.isLowered = true;
		}
	}

    void ResetVol()
	{
		AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioID == tmpName);
		s.source.volume = tmpVol;
		isLowered = false;
	}


    #endregion
}
