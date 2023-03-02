using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour {

    private int healAmount = 15;
    private int selfDestruction = 5;

    private void Start()
    {
        Destroy(gameObject, selfDestruction);
    }

    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject.tag == "Player")
        {
            collisionObject.GetComponent<ControlPlayer>().HealLife(healAmount);
            Destroy(gameObject);
        }
    }
}
