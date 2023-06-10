using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private float _groundCheckDistance = 0.3f;

    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _sunRoofLayerMask;
    [SerializeField] private Transform _groundCheckObject;

    public bool IsOnGround()
    {
        Collider2D isGrounded = Physics2D.OverlapCircle(_groundCheckObject.position, _groundCheckDistance, _groundLayerMask);
        Collider2D isSunRoofed = Physics2D.OverlapCircle(_groundCheckObject.position, _groundCheckDistance, _sunRoofLayerMask);
        if (isGrounded)
        {
            return isGrounded;
        }
        if(isSunRoofed)
        {
            return isSunRoofed;
        }
        if(!isGrounded && !isSunRoofed)
        {
            return false;
        }
        else
        {
            return isGrounded;
        }
        
    }

}
