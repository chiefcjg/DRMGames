using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            GameObject.Find("GameManager").GetComponent<GameMain>().player1Ready = true;
            Debug.Log("test");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRplayer")
        {
            GameObject.Find("GameManager").GetComponent<GameMain>().player1Ready = false;
            Debug.Log("test2");
        }
    }

}
