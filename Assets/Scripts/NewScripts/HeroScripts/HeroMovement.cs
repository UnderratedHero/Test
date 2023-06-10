using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private HeroMovementInput MovementMethod;

    private void Update()
    {
        MovementMethod.Move();
        
        MovementMethod.Jump();

        MovementMethod.Crouch();
    }

}
