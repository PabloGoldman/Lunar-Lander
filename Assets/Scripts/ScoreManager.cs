using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Get().score;
    }
}
