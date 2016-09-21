using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class obj_syncPos : NetworkBehaviour
{

    [SyncVar]
    private Vector3 syncPos;

    [SerializeField]
    Transform myT;
    [SerializeField]
    float lerpRate = 15;

    void FixedUpdate()
    {
        TransmitPosition();
        LerpPos();
    }

    void LerpPos()
    {
        myT.position = Vector3.Lerp(myT.position, syncPos, Time.deltaTime * lerpRate);
    }

    [Command]
    void CmdProvidePositionToServer(Vector3 pos)
    {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        CmdProvidePositionToServer(myT.position);
    }

}

