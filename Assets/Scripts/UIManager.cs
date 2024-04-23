using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject Failed, Retry,TapToPlay;


    void Start()
    {
        Failed.SetActive(false);
        Retry.SetActive(false);
        TapToPlay.SetActive(true);

    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(0);
    }
    public void playerMovement()
    {
        PlayerMovement.instance.MainAnim();
    }
}
