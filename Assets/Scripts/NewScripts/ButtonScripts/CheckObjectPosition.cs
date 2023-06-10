using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectPosition : MonoBehaviour
{
    [SerializeField] private Transform _moveTargetLeft;
    [SerializeField] private Transform _moveTargetRight;
    [SerializeField] private Transform _objectToCheck;
    private bool isColl = false;

    public enum PositionStatements
    { 
        LeftIdlePos, RightIdlePos, MovingLeft, MovingRight
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ButtonInCollisison");
        isColl = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("ButtonOutCollisison");
        isColl = false;
    }
    public PositionStatements CheckPosition()
    {
        if (isColl)
        {
            if (_objectToCheck.position == _moveTargetLeft.position)
            {
                return PositionStatements.LeftIdlePos;
            }
            else
            {
                return PositionStatements.MovingLeft;
            }
        }
        else
        {
            if (_objectToCheck.position == _moveTargetRight.position)
            {
                return PositionStatements.RightIdlePos;
            }
            else
            {
                return PositionStatements.MovingRight;
            }
        }    
    }
}
