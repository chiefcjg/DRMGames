using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int playerspassed;
    public GameObject[] players;

    private void Update()
    {
        if(playerspassed == 2)
        {
            StartCoroutine(FadeImage(false));
            StartCoroutine(DialogWait());
            GameObject.Find("GameManager").GetComponent<GameMain>().onGameEnd();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerspassed++;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerspassed--;
        }
    }

    IEnumerator DialogWait()
    {
        yield return new WaitForSeconds(10);
        GameObject.Find("GameManager").GetComponent<GameMain>().gameRun = false;
        StartCoroutine(FadeImage(true));

    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade out the black
        if (fadeAway)
        {
            // loop over 10 second backwards
            for (float i = 10; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                GameObject.Find("GameManager").GetComponent<GameMain>().img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade in the black
        else
        {
            // loop over 10 second
            for (float i = 0; i <= 10; i += Time.deltaTime)
            {
                // set color with i as alpha
                GameObject.Find("GameManager").GetComponent<GameMain>().img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
