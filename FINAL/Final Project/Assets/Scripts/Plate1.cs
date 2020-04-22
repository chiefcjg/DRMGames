using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate1 : MonoBehaviour
{
    public Vector3 endPosition;
    public Vector3 originalLocation;
    public Vector3 movingLocation;
    public bool MovingPlateDone = false;
    public bool MovePlate = false;

    private void Awake()
    {
        originalLocation = this.transform.position;
        endPosition = new Vector3(originalLocation.x, (originalLocation.y - 0.1f), originalLocation.z);
    }

    private void Update()
    {
        if (this.transform.position == endPosition)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            MovingPlateDone = true;
        }
        if (MovePlate == true)
        {
            PlayerHere();
        }
        if(MovingPlateDone == true)
        {
            GameObject.Find("GameManager").GetComponent<GameMain>().Plate1Ready = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            MovePlate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            MovePlate = false;
        }
    }

    public void PlayerHere()
    {
        this.gameObject.transform.position = new Vector3(originalLocation.x, (originalLocation.y - 0.1f), originalLocation.z);
    }
}
