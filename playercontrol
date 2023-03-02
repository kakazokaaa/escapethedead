using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IDeath, IHeal
{

    private Vector3 direction;
    public LayerMask LayerMask;
    public InterfaceControl scriptInterfaceControl;
    public AudioClip DamageAudio;
    private PlayerMovement myPlayerMovement;
    private CharacterAnimation playerAnimation;
    [HideInInspector]
    public Status playerStatus;
    public GameObject PlayerBloodParticle;

    private void Start()
    {
        myPlayerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<CharacterAnimation>();
        playerStatus = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {

        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(eixoX, 0, axisZ);

        playerAnimation.Movement(direction.magnitude);
    }

    void FixedUpdate()
    {
        myPlayerMovement.Movement(direction, playerStatus.Velocity);

        myPlayerMovement.PlayerRotation(LayerMask);
    }

    public void TakeDamage (int damage)
    {
        playerStatus.Life -= damage;
        scriptInterfaceControl.UpdateSliderPlayerLife();
        AudioControl.instance.PlayOneShot(DamageAudio);
        if(playerStatus.Life <= 0)
        {
            Death();
        }        
    }

    public void BloodParticle(Vector3 position, Quaternion rotation)
    {
        Instantiate(PlayerBloodParticle, position, rotation);
    }

    public void Death ()
    {
        scriptInterfaceControl.GameOver();
    }

    public void HealLife (int healAmount)
    {
        playerStatus.Life += healAmount;
        if(playerStatus.Life > playerStatus.InitialLife)
        {
            playerStatus.Life = playerStatus.InitialLife;
        }
        scriptInterfaceControl.UpdateSliderPlayerLife();
    }
}
