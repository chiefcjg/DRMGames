﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{
    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;


    float m_Speed = 0.0f;

    CharacterController m_CharacterController = null;
    Transform m_CameraRig = null;
    Transform m_Head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        HandeleHead();
        HandleHeight();
        CalculateMovement();
    }

    void HandeleHead()
    {
        // store current
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        //rotation
        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        //restore
        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }

    void CalculateMovement()
    {
        //movement orientation
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        //if not moving
        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_Speed = 0;
        }

        // if button pressed
        if (m_MovePress.state)
        {
            // add the clamp
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            // orientation
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }


        // apply
        m_CharacterController.Move(movement);
    }

    void HandleHeight()
    {
        // get the head in local space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_CharacterController.height = headHeight;

        // cut it in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        //move capsule in local
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        //rotate this motion
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        //apply
        m_CharacterController.center = newCenter;
    }
}
