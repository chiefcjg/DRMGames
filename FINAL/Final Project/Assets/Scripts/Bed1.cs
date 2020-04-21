using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed1 : MonoBehaviour
{
    public GameObject playerinBed;
    public Transform spawnlocation;

    private void Awake()
    {
        spawnlocation = GameObject.Find("Spawn location 1").transform;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            playerinBed = other.gameObject;
            GameObject.Find("GameManager").GetComponent<GameMain>().player1Ready = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            playerinBed = null;
            GameObject.Find("GameManager").GetComponent<GameMain>().player1Ready = false;
        }
    }
    public void Sleeptimemove()
    {
        playerinBed.transform.position = spawnlocation.position;
    }
}
