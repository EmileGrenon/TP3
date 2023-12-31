using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float sprintMultiplier;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float mouseMutiplier;

    Animator animator;
    CharacterController cc;
    Camera cam;

    Vector3 cameraRotation = Vector3.zero;
    Vector3 jumpMovement = Vector3.zero;

    PlayerMovement playerMovement;
    InputAction move;
    InputAction jump;
    InputAction sprint;
    InputAction camMovement;
    void Awake()
    {
        playerMovement = new PlayerMovement();
    }
    void OnEnable()
    {
        move = playerMovement.Player.Move;
        move.Enable();
        jump = playerMovement.Player.Jump;
        jump.Enable();
        sprint = playerMovement.Player.Sprint;
        sprint.Enable();
        camMovement = playerMovement.Player.Look;
        camMovement.Enable();
    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
        sprint.Disable();
        camMovement.Disable();
    }
    void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
        CameraRotation();
    }
    void Movement()
    {
        Vector2 action = move.ReadValue<Vector2>();
        Vector3 direction = cam.transform.forward * action.y + cam.transform.right * action.x;
        if (direction.magnitude > 0)
        {
            animator.SetBool("Walk", true);

            direction = new Vector3(direction.x, 0, direction.z).normalized;

            if (sprint.ReadValue<float>() > 0.1f)
            {
                direction *= sprintMultiplier;
                animator.SetBool("Sprint", true);
            }
            else
            {
                animator.SetBool("Sprint", false);
            }
        }
        else
        {
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", false);
        }
        // isGrounded ne marche pas quand le joueur est dans son animation de idle
        if (cc.isGrounded)
        {
            if (jump.ReadValue<float>() > 0.1f)
            {
                jumpMovement = Vector3.up * jumpForce;
                animator.SetTrigger("Jump");
            }
            jumpMovement.y = Mathf.Max(-0.5f, jumpMovement.y);
        }
        else
        {
            jumpMovement -= Vector3.up * Time.deltaTime * gravity;
        }
        //transform.Translate(new Vector3(direction.x * speed * Time.deltaTime, 0, direction.y * speed * Time.deltaTime));
        cc.Move((direction * speed + jumpMovement) * Time.deltaTime);
    }
    void CameraRotation()
    {
        Vector2 action = camMovement.ReadValue<Vector2>();
        cameraRotation += new Vector3(-action.y * mouseMutiplier * Time.deltaTime, action.x * mouseMutiplier * Time.deltaTime, 0);

        
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -60, 60);
        transform.rotation = Quaternion.Euler(new Vector3(0, cameraRotation.y, 0));
        cam.transform.rotation = Quaternion.Euler(cameraRotation);
    }
}
