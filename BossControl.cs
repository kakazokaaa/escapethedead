using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossControl : MonoBehaviour, IDeath {

    private Transform player;
    private NavMeshAgent agent;
    private Status bossStatus;
    private CharacterAnimation bossAnimation;
    private CharacterMovement bossMovement;
    public GameObject MedKitPrefab;
    public Slider sliderBossLife;
    public Image ImageSlider;
    public Color ColorMaxHealth, ColorMinHealth;
    public GameObject ZombieBloodParticle;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossStatus = GetComponent<Status>();
        agent.speed = bossStatus.Velocity;
        bossAnimation = GetComponent<CharacterAnimation>();
        bossMovement = GetComponent<CharacterMovement>();
        sliderBossLife.maxValue = bossStatus.InitialLife;
        UpdateInterface();
    }

    private void Update()
    {
        agent.SetDestination(player.position);
        bossAnimation.Movement(agent.velocity.magnitude);

        if(agent.hasPath == true)
        { 
        bool closePlayer = agent.remainingDistance <= agente.stoppingDistance;

        if(closePlayer)
        {
            bossAnimation.Attack(true);
                Vector3 direction = player.position - transform.position;
                bossMovement.Rotate(direction);
        }
        else
        {
            bossAnimation.Attack(false);
        }
        }
    }

    void AttackPlayer ()
    {
        int damage = Random.Range(30, 40);
        player.GetComponent<ControlPlayer>().TakeDamage(damage);
        Quaternion rotationOpposedAttack = Quaternion.LookRotation(-transform.forward);
        player.GetComponent<ControlPlayer>().BloodParticle(transform.position, rotationOpposedAttack);
    }

    public void TakeDamage(int damage)
    {
        bossStatus.Life -= damage;
        UpateInterface();
        if (bossStatus.Life <= 0)
        {
            Death();
        }
    }

    public void BloodParticle(Vector3 position, Quaternion rotacao)
    {
        Instantiate(ZombieBloodParticle, position, rotation);
    }

    public void Death()
    {
        bossAnimation.Death();
        bossMovement.Death();
        this.enabled = false;
        agent.enabled = false;
        Instantiate(MedKitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 2);
    }

    void UpdateInterface()
    {
        sliderBossLife.value = bossStatus.Life;
        float lifePercentage = (float)bossStatus.Life / bossStatus.InitialLife;
        Color lifeColor = Color.Lerp(ColorMinHealth, ColorMaxHealth, lifePercentage);
        ImageSlider.color = lifeColor;
    }
}
