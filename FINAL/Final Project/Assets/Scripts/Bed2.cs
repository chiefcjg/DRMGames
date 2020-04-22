using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed2 : MonoBehaviour
{
    public GameObject playerinBed = null;
    public Transform spawnlocation = null;

    private void Awake()
    {
        spawnlocation = GameObject.Find("Spawn location 2").transform;
    }

    //finds the player, makes it player two
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerinBed = other.gameObject;
            playerinBed.gameObject.GetComponent<PlayerScript>().Player = 2;
            GameObject.Find("GameManager").GetComponent<GameMain>().player2Ready = true;
        }
    }

    //bye player
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerinBed.gameObject.GetComponent<PlayerScript>().Player = 0;
            playerinBed = null;
            GameObject.Find("GameManager").GetComponent<GameMain>().player2Ready = false;
        }
    }

    //finds the player, moves them to their spawn
    public void Sleeptimemove()
    {
        playerinBed.transform.position = spawnlocation.position;
    }
}
