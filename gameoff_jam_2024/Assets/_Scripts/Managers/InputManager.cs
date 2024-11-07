using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityUtils;

public class InputManager : PersistentSingleton<InputManager>
{
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference look; 
    
    public Vector2 MoveInput => move.action.ReadValue<Vector2>();
    public Vector2 LookInput => look.action.ReadValue<Vector2>();
    public bool JumpInput => jump.action.IsPressed();
    
    protected override void Awake()
    {
        base.Awake();
        move.action.Enable();
        jump.action.Enable();
        look.action.Enable();
    }
}