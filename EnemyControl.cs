using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IDeath
{

    public GameObject Player;
    private CharacterMovement enemyMovement;
    private CharacterAnimation enemyAnimation;
    private Status enemyStatus;
    public AudioClip DeathAudio;
    private Vector3 randomPosition;
    private Vector3 direction;
    private float wanderCounter;
    private float timeBetweenRandomPositions = 4;
    private float GenerateMedKitPercentage = 0.1f;
    public GameObject MedKitPrefab;
    private InterfaceControl scriptInterfaceControl;
    [HideInInspector]
    public ZombieGenerator myGenerator;
    public GameObject ZombieBloodParticle;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        enemyAnimation = GetComponent<CharacterAnimation>();
        enemyMovement = GetComponent<CharacterMovement>();
        RnadomizeZombie();
        enemyStatus = GetComponent<Status>();
        scriptInterfaceControl = GameObject.FindObjectOfType(typeof(InterfaceControl)) as InterfaceControl;
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        enemyMovement.Rotate(direction);
        enemyAnimation.Movement(direction.magnitude);

        if(distance > 15)
        {
            Wander ();
        }
        else if (distance > 2.5)
        {
            direction = Player.transform.position - transform.position;

            enemyMovement.Movement(direction, enemyStatus.Velocity);

            enemyAnimation.Attack(false);
        }
        else
        {
            direction = Player.transform.position - transform.position;

            enemyAnimation.Attack(true);
        }
    }

    void Wander ()
    {
        wanderCounter -= Time.deltaTime;
        if(wanderCounter <= 0)
        {
            randomPosition = RandomizePosition();
            wanderCounter += timeBetweenRandomPositions + Random.Range(-1f, 1f);
        }

        bool closeEnough = Vector3.Distance(transform.position, randomPosition) <= 0.05;
        if (closeEnough == false)
        {
            direction = randomPosition - transform.position;
            enemyMovement.Movement(direction, enemyStatus.Velocity);
        }           
    }

    Vector3 RandomizePosition ()
    {
        Vector3 position = Random.insideUnitSphere * 10;
        position += transform.position;
        position.y = transform.position.y;

        return position;
    }

    void AttackPlayer ()
    {
        int damage = Random.Range(20, 30);
        Player.GetComponent<PlayerControl>().TakeDamage(damage);
        Quaternion rotationOpposedAttack = Quaternion.LookRotation(-transform.forward);
        Player.GetComponent<PlayerControl>().bloodParticle(transform.position, rotationOpposedAttack);
    }

    void RandomizeZombie ()
    {
        int generateTypeZombie = Random.Range(1, transform.childCount);
        transform.GetChild(generateTypeZombie).gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        enemyStatus.Life -= damage;
        if(enemyStatus.Life <= 0)
        {
            Death();
        }
    }

    public void Blood Particle (Vector3 position, Quaternion rotation)
    {
        Instantiate(ZombieBloodParticle, position, rotation);
    }

    public void Death()
    {
        Destroy(gameObject, 2);
        enemyAnimation.Death();
        enemyMovement.Death();
        this.enabled = false;
        AudioControl.instance.PlayOneShot(DeathAudio);
        VerifyMedKitGeneration(generateMedKitPercentage);
        scriptInterfaceControl.UpdateDeadZombies();
        myGenerator.DecreaseAmountZombiesAlive();
    }

    void VerifyMedKitGeneration(float generationPercentage)
    {
        if(Random.value <= generationPercentage)
        {
            Instantiate(MedKitPrefab, transform.position, Quaternion.identity);
        }
    }
}
