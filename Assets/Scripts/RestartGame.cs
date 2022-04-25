using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            GameManager.Get().ResetScene();
        }
    }
}
