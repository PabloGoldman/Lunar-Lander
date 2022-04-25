using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePause : MonoBehaviour
{
    [SerializeField] GameObject inGamePause;

    bool inPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        inGamePause.SetActive(true);
        inPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        inGamePause.SetActive(false);
        inPause = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
