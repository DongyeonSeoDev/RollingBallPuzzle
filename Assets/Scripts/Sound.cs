using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource sound = null;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SoundVolumeChange();
    }

    public void SoundVolumeChange()
    {
        if (GameManager.Instance.isMute)
        {
            sound.volume = 0f;
        }
        else
        {
            sound.volume = 1f;
        }
    }
}
