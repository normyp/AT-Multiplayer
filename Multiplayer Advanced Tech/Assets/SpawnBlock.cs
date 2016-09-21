using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public GameObject bullet;

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0,0,3), transform.position);
        }
	}
}
