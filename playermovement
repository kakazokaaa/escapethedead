using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public void PlayerRotation (LayerMask GroundMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, 100, GroundMask))
        {
            Vector3 positionPlayerAim = impact.point - transform.position;

            positionPlayerAim.y = transform.position.y;

            Rotate(positionPlayerAim);
        }
    }
}
