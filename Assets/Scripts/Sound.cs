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
        if (GameManager.Instance.isMute)
        {
            sound.Stop();
        }
    }
}
