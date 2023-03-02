using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject Player;
    private Vector3 distCompensate;

	// Use this for initialization
	void Start () {
        distCompensate = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position + distCompensate;
	}
}
