using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceBlue,audioSourceRed,audioSourceCon,audioSourceCollect;
    public AudioClip blueDoor,redDoor,confetti,collect;
    public GameObject soundManager;
    public static SoundManager instance;
    private void Start()
    {
        instance = this;
        
    }
}
