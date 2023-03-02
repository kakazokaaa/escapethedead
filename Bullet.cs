using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Velocity = 20;
    private Rigidbody rigidbodyBullet;
    public AudioClip DeathAudio;

    private void Start()
    {
        rigidbodyBullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rigidbodyBullet.MovePosition
            (rigidbodyBullet.position + 
            transform.forward * Velocity * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collisionObject)
    {
        Quaternion rotationOpposedBullet = Quaternion.LookRotation(-transform.forward);
        switch(collisionObject.tag)
        {
            case "Enemy":
                EnemyControl enemy = collisionObject.GetComponent<EnemyControl>();
                enemy.TakeDamage(1);
                enemy.BloodParticle(transform.position, totationOpposedBullet);
            break;

            case "Boss":
                BossControl boss = collisionObject.GetComponent<BossControl>();
                boss.TakeDamage(1);
                boss.BloodParticle(transform.position, rotationOpposedBullet);
            break;
        }

        Destroy(gameObject);
    }
}
