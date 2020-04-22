using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierAI : MonoBehaviour
{
    //finds the AI, makes the wall disabled
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            GetComponent<MeshCollider>().enabled = false;
        }
    }

    //bye AI
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "AI")
        {
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
