using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public GameObject Zombie;
    private float timeCounter = 0;
    public float TimeGenerateZombie = 1;
    public LayerMask LayerZombie;
    private float generationDistance = 3;
    private float DistancePlayerGeneration = 20;
    private GameObject player;
    private int maxZombiesAlive = 2;
    private int zombiesAlive;
    private float timeNextIncreaseDifficulty = 30;
    private float counterIncreaseDifficulty;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        counterIncreaseDifficulty = timeNextIncreaseDifficulty;
        for(int i = 0; i < maxZombiesAlive; i ++)
        {
            StartCoroutine(GenerateNewZombie());
        }
    }

    // Update is called once per frame
    void Update () {

        bool canGenerateZombiesDistance = Vector3.Distance(transform.position,
            player.transform.position) >
            DistancePlayerGeneration;

        if (canGenerateZombiesDistance == true && zombiesAlive < maxZombiesAlive)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= TimeGenerateZombie)
            {
                StartCoroutine(GenerateNewZombie());
                timeCounter = 0;
            }
        }        

        if(Time.timeSinceLevelLoad > counterIncreaseDifficulty)
        {
            maxZombiesAlive++;
            counterIncreaseDifficulty = Time.timeSinceLevelLoad + timeNextIncreaseDifficulty;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, generationDistance);
    }

    IEnumerator GenerateNewZombie ()
    {
        Vector3 creationPosition = RandomizePosition();
        Collider[] colliders = Physics.OverlapSphere(creationPosition, 1, LayerZombie);

        while(colisores.Length > 0)
        {
            creationPosition = RandomizePosition();
            colliders = Physics.OverlapSphere(creationPosition, 1, LayerZumbi);
            yield return null;
        }

        EnemyControl zombie = Instantiate(Zombie, creationPosition, transform.rotation).GetComponent<EnemyControl>();
        zombie.myGenerator = this;
        zombiesAlive++;
    }

    Vector3 RandomizePosition ()
    {
        Vector3 posicao = Random.insideUnitSphere * generationDistance;
        position += transform.position;
        position.y = 0;

        return position;
    }

    public void DecreaseAmountZombiesAlive()
    {
       zombiesAlive--;
    }
}
