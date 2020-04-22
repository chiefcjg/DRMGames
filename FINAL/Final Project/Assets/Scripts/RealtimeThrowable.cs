using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Valve.VR.InteractionSystem;

public class RealtimeThrowable : Throwable
{
    private RealtimeTransform rtTransform;
    private RealtimeView rtView;
    public int ownership = -1;

    // Start is called before the first frame update
    void Start()
    {
        rtTransform = gameObject.GetComponent<RealtimeTransform>();
        rtView = gameObject.GetComponent<RealtimeView>();
    }
    public void Grabbed()
    {
        rtTransform.RequestOwnership();
        rtView.RequestOwnership();
        ownership = rtTransform.ownerID;
    }
    public override void OnHandHoverBegin(Hand hand)
    {
        GrabTypes bestGrabType = hand.GetBestGrabbingType();

        if (bestGrabType != GrabTypes.None && rtTransform.ownerID == -1)
        {
            hand.AttachObject(gameObject, bestGrabType, attachmentFlags);
        }

    }
    
}
