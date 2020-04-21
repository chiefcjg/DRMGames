using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            GameObject.Find("GameManager").GetComponent<GameMain>().player2Ready = true;
            Debug.Log("test");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            GameObject.Find("GameManager").GetComponent<GameMain>().player2Ready = false;
            Debug.Log("test2");
        }
    }
}
