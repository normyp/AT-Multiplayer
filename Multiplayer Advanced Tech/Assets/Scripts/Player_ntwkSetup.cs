using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ntwkSetup : NetworkBehaviour {

    [SerializeField]
    Camera FPSCam;
    [SerializeField]
    AudioListener audioL;

	// Use this for initialization
	void Start () {
	    if(isLocalPlayer)
        {
            GameObject.Find("Scene Camera").SetActive(false);
            GetComponent<CharacterController>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            FPSCam.enabled = true;
            audioL.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
