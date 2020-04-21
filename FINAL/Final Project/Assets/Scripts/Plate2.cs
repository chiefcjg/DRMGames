using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour
{
    public Vector3 originalLocation;

    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 0.5f;

    private void Awake()
    {
        originalLocation = this.gameObject.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            while(other.tag == "VRPlayer")
            {
                //get the objects current position and put it in a variable so we can access it later with less code
                Vector3 pos = this.transform.position;
                //calculate what the new Y position will be
                float newY = Mathf.Sin(Time.time * speed);
                //set the object's Y to the new calculated Y
                this.transform.position = new Vector3(pos.x, newY, pos.z) * height;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VRPlayer")
        {
            this.transform.position = originalLocation;
        }
    }
}
