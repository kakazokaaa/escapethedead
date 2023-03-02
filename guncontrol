using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

    public GameObject Bullet;
    public GameObject GunBarrel;
    public AudioClip GunshotAudio;
    
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, GunBarrel.transform.position, GunBarrel.transform.rotation);
            AudioControl.instance.PlayOneShot(GunshotAudio);
        }
	}
}
