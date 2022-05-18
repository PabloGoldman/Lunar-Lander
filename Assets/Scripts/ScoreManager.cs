using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject winPanel;
    [SerializeField] Player player;

    void Update()
    {
        scoreText.text = "Score: " + player.GetScore();

        if (player.score == 3)
        {
            WinText();
        }
    }

    void WinText()
    {
        winPanel.SetActive(true);
    }
}
