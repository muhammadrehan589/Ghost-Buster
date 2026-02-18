using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance;
    [HideInInspector]public Controls controls;
    [HideInInspector]public Vector2 moveInput;

    private void Awake()
    {
        if (Instance == null)   
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        controls = new Controls();
        controls.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
