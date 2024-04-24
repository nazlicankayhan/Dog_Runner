using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerDog : MonoBehaviour
{
    public Transform Dog;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bigger"))
        {
            transform.localScale = transform.localScale + new Vector3(0.2f, 0.2f, 0.2f);
            Score.score += 5;
            SoundManager.instance.audioSource.clip = SoundManager.instance.Correct;
            SoundManager.instance.audioSource.Play();
        }
    }
}
