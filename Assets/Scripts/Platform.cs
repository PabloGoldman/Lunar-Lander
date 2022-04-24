using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool alreadyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlatformActivation());
        }
    }
    IEnumerator PlatformActivation()
    {
        float t = 0;
        float maxTime = 0.5f;

        while (t < maxTime && !alreadyPressed)
        {
            t += Time.deltaTime;
            transform.position -= new Vector3(0, t * Time.deltaTime, 0);

            yield return null;
        }
        alreadyPressed = true;
    }
}
