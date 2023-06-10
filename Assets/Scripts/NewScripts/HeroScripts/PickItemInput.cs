using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickItemInput : MonoBehaviour
{
    [SerializeField] private ChangeItemHierarchy ParentObjectMethod;
    [SerializeField] private ChangeColor PickColorMethod;
    private bool inTriggerZone = false;

    public enum HierarchyStatement
    {
        InParentHierarchy, OutParentHierarchy
    }
    private void Update()
    {
        if(inTriggerZone && Input.GetKeyDown(KeyCode.LeftShift))
        {
            CheckInput(true);

            inTriggerZone = true;
        }
        else if(!inTriggerZone && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Nothing happens");
        }
        if(inTriggerZone && Input.GetKeyUp(KeyCode.LeftShift))
        {
            CheckInput(false);
        }
        else if(!inTriggerZone && Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Nothing happens");
        }
    
    }

    private void CheckInput(bool state)
    {
        if (state)
        {
            ParentObjectMethod.ChangeItemHierarcy(HierarchyStatement.InParentHierarchy);

            PickColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.PickItem);
        }
        else
        {
            ParentObjectMethod.ChangeItemHierarcy(HierarchyStatement.OutParentHierarchy);

            PickColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.Idle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            inTriggerZone= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            inTriggerZone = false;
        }
    }

}
