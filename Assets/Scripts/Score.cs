using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;
    public TMP_Text score_text;
    void Start()
    {
        score = 0;
    }
    void Update()
    {
        score_text.text = score.ToString();

    }
}
