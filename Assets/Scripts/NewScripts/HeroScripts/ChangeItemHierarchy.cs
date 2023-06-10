using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeItemHierarchy : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private Rigidbody2D _RigB;
    private SpriteRenderer _SpriteR;
    private CircleCollider2D item;
    private bool _getCompinents = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            if (_getCompinents == false)
            {
                _getCompinents = true;
                _RigB = collision.GetComponent<Rigidbody2D>();
                _SpriteR = collision.GetComponentInChildren<SpriteRenderer>();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            item = circle;   
        }
    }

    public void ChangeItemHierarcy(PickItemInput.HierarchyStatement value)
    {
        switch(value)
        {
            case PickItemInput.HierarchyStatement.InParentHierarchy:
            {
                _RigB.constraints = RigidbodyConstraints2D.FreezePositionY;
                _SpriteR.enabled = false;
                item.transform.SetParent(_parent);
                item.transform.position = _parent.position;
                item.enabled = false;
                break;
            }
            case PickItemInput.HierarchyStatement.OutParentHierarchy: 
            {
                _RigB.constraints = RigidbodyConstraints2D.None;
                _SpriteR.enabled = true;
                item.transform.position = new Vector3(_parent.position.x + 2,_parent.position.y + 1,_parent.position.z);
                item.transform.SetParent(null);
                item.enabled = true; 
                break; 
            }
        }
    }
}
