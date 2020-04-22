using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed1 : MonoBehaviour
{
    public GameObject playerinBed = null;
    public Transform spawnlocation = null;

    private void Awake()
    {
        spawnlocation = GameObject.Find("Spawn location 1").transform;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            playerinBed = other.gameObject;
            playerinBed.gameObject.GetComponent<PlayerScript>().Player = 1;
            GameObject.Find("GameManager").GetComponent<GameMain>().player1Ready = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
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
