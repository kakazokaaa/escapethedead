using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator myAnimator;

    void Awake ()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack (bool status)
    {
        myAnimator.SetBool("Attacking", status);
    }

    public void Movement (float movementValue)
    {
        myAnimator.SetFloat("Moving", movementValue);
    }

    public void Death()
    {
        myAnimator.SetTrigger("Death");
    }
}
