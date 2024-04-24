using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Correct;
    public GameObject soundManager;
    public static SoundManager instance;
    private void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
}
