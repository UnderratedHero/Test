using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ButtonCollisionHandler: MonoBehaviour
{
    private bool isCollision = false;

    [SerializeField] private GameObject _object;
    [SerializeField] private MoveForward _objectMethod;
    [SerializeField] private CheckObjectPosition _checkPosMethod;
    [SerializeField] private ChangeColor _collisionColorMethod;

    public enum ObjectStatement
    {
        Open, Close, IdleLeft, IdleRight
    }
    public ObjectStatement statement;

    private void OnCollisionStay2D(Collision2D collision)
    {
        _collisionColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.PickItem);
        isCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _collisionColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.Idle);
        isCollision = false;
    }

    private void Update()
    {
        if(isCollision)
        {

            if (_checkPosMethod.CheckPosition() == CheckObjectPosition.PositionStatements.LeftIdlePos)
            {
                _objectMethod.MoveStatement(ObjectStatement.IdleLeft);
            }
            else if (_checkPosMethod.CheckPosition() == CheckObjectPosition.PositionStatements.MovingLeft)
            {
                _objectMethod.MoveStatement(ObjectStatement.Close);
            }
        }
        else
        {

            if (_checkPosMethod.CheckPosition() == CheckObjectPosition.PositionStatements.RightIdlePos)
            {
                _objectMethod.MoveStatement(ObjectStatement.IdleRight);
            }
            else if (_checkPosMethod.CheckPosition() == CheckObjectPosition.PositionStatements.MovingRight)
            {
                _objectMethod.MoveStatement(ObjectStatement.Open);
            }
        }

    }

   
}
