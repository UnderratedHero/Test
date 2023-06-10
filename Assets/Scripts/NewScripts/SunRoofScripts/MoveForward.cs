using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ButtonCollisionHandler;

public class MoveForward : MonoBehaviour
{

    private Rigidbody2D _ObjRigB;
    private Transform _transformObj;
    private Vector3 _moveDirection;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _moveTargetRight;

    private void Awake()
    {
        _ObjRigB = GetComponent<Rigidbody2D>();
        _transformObj = GetComponent<Transform>();
        _transformObj.position = _moveTargetRight.position;
        _ObjRigB.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void FixedUpdate()
    {
        MoveInternal();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
        Vector3 _velocity = _moveDirection * _moveSpeed;

        Vector3 _worldVelocity = transform.TransformVector(_velocity);

        _ObjRigB.velocity = _worldVelocity;
    }

    public void MoveStatement(ObjectStatement state)
    {
        ObjectStatement statement = state;
        switch (statement)
        {
            case ObjectStatement.Open:
                {
                    Debug.Log("OpenState");

                    _ObjRigB.constraints = RigidbodyConstraints2D.FreezePositionY;

                    _transformObj.rotation = Quaternion.identity;

                    Move(new(1, 0, 0));

                    break;
                }
            case ObjectStatement.Close:
                {
                    Debug.Log("CloseState");

                    _ObjRigB.constraints =  RigidbodyConstraints2D.FreezePositionY;

                    _transformObj.rotation = Quaternion.identity;

                    Move(new(-1, 0, 0));

                    break;
                }
            case ObjectStatement.IdleLeft:
                {
                    Debug.Log("LeftIdleState");

                    _ObjRigB.constraints = RigidbodyConstraints2D.FreezeAll;

                    break;
                }
            case ObjectStatement.IdleRight:
                {
                    Debug.Log("RightIdleState");

                    _ObjRigB.constraints = RigidbodyConstraints2D.FreezeAll;

                    break;
                }

        }
    }
}
