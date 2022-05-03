using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool pressed = false;

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

        while (t < maxTime && !pressed)
        {
            t += Time.deltaTime;
            transform.position -= new Vector3(0, t * Time.deltaTime, 0);

            yield return null;
        }
        pressed = true;
    }
}
