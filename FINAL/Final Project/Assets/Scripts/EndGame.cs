using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int playerspassed;
    public GameObject[] players;

    //checks to see if game is over.
    private void Update()
    {
        if (playerspassed == 2)
        {
            StartCoroutine(DialogWait());
        }
    }

    //checks to ensure players only count as spawn.
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerspassed++;
        }
    }
    //incase they go back in.
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerspassed--;
        }
    }

    // gives a timer for dialog.
    IEnumerator DialogWait()
    {
        GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(8);
        GameObject.Find("GameManager").GetComponent<GameMain>().gameRun = false;
        GameObject.Find("GameManager").GetComponent<GameMain>().onGameEnd();
    }
}
