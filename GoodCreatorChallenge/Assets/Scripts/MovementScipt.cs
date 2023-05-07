using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScipt : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private float player_speed = 12.0f;
    private float gravity_value = -9.81f;

    [SerializeField] private Transform ground_checker;
    [SerializeField] private float ground_distance = 0.4f;
    [SerializeField] private LayerMask ground_mask;
   
    private bool grounded_player;
    private Vector3 velocity;

    [SerializeField] public int additional_jumps = 0;
    private int total_jumps = 1;
    private float jump_height = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded_player = Physics.CheckSphere(ground_checker.position, ground_distance, ground_mask);

        if (grounded_player && velocity.y < 0.0f)
        {
            velocity.y = -2f;
            total_jumps = 1 + additional_jumps;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       
        velocity.y += gravity_value * Time.deltaTime;

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        if(Input.GetButtonDown("Jump") && (grounded_player || total_jumps > 0))
        {
            total_jumps--;
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity_value);
        }

        controller.Move(movement * player_speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
        
    }
}
