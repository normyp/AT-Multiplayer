using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_syncPos : NetworkBehaviour {

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
        if(!isLocalPlayer)
        {
            myT.position = Vector3.Lerp(myT.position, syncPos, Time.deltaTime * lerpRate);
        }    
    }

    [Command]
    void CmdProvidePositionToServer(Vector3 pos)
    {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        if (isLocalPlayer)
        {
            CmdProvidePositionToServer(myT.position);
        }
    }

}
