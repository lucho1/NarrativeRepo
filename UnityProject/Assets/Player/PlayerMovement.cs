using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // --- Player Movement Variables ---
    public float Speed = 12.0f;
    public float Gravity = -9.81f;

    private CharacterController PlayerController;
    private Vector3 Velocity = new Vector3(0.0f, 0.0f, 0.0f);

    // --- Ground Check Variables ---
    [SerializeField]
    private Transform GroundCheckObject;

    [SerializeField]
    private float SphereCheckRadius = 0.4f;
    
    [SerializeField]
    private LayerMask GroundMask;

    private bool IsInGround = true;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController)
        {
            Debug.LogError("Player has no CharacterController!!");
            return;
        }

        // --- Ground Check ---
        IsInGround = Physics.CheckSphere(GroundCheckObject.position, SphereCheckRadius, GroundMask);

        if (IsInGround && Velocity.y < 0.0f)
            Velocity.y = 0.0f;

        // --- Movement ---
        float MovX = Input.GetAxis("Horizontal");
        float MovZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * MovX + transform.forward * MovZ;
        movement *= Speed * Time.deltaTime;
        PlayerController.Move(movement);

        // --- Gravity ---
        // Free fall: Grav. is an acceleration, so time is squared in free fall
        Velocity.y += Gravity * Time.deltaTime * Time.deltaTime;
        PlayerController.Move(Velocity);
    }
}
