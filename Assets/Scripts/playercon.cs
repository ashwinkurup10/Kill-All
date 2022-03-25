using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playercon : MonoBehaviour
{


    PlayerControls controls;
    Animator anim;
    Vector2 move;
    Vector2 rotate;

    void Awake()
    {
        controls = new PlayerControls();



        controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;

        controls.GamePlay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.GamePlay.Rotate.canceled += ctx => rotate = Vector2.zero;

    }

   

    void Update()
    {
        
        Vector2 m = new Vector2(-move.x, -move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector3 r = new Vector3(-rotate.y, rotate.x) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.Self);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        controls.GamePlay.Disable();
    }

   
}
