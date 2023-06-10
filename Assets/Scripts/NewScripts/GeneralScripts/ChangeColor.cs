using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color _mainColor;
    private SpriteRenderer _sprite;

    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    public enum ColorStatements
    {
        Crouch, PickItem, Idle
    }

    ColorStatements ObjectColorStatements;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _mainColor = _sprite.color;
    }

    public void ChangeObjectColor(ColorStatements value)
    {
        ObjectColorStatements = value;
        switch (ObjectColorStatements)
        {
            case ColorStatements.Crouch:
            {
                Debug.Log("CrouchColorStatement");
                _sprite.color = color1;
                break;
            }
            case ColorStatements.PickItem: 
            {
                Debug.Log("PickItemColorStatement");
                _sprite.color = color2;
                break;                
            }
            case ColorStatements.Idle:
            {
                Debug.Log("CrouchColorStatement");
                _sprite.color = _mainColor;
                break;
            }
        }
    }
}
