using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Player player;

    private void Start()
    {

    }

    void Update()
    {
        scoreText.text = "Score: " + player.GetScore();
    }
}
