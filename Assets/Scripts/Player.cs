using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float move_speed;
    [SerializeField] private Rigidbody2D rigidbody_2d;
    [SerializeField] private Animator animator;
    private Vector2 movement;
    private Vector3 rotation = new Vector3();

    private void Awake()
    {
        rotation = Vector3.zero;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotation.y = 180f;
            gameObject.transform.eulerAngles = rotation;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotation.y = 0f;
            gameObject.transform.eulerAngles = rotation;
        }

    }

    void FixedUpdate()
    {
        rigidbody_2d.MovePosition(rigidbody_2d.position + movement * move_speed * Time.fixedDeltaTime);
    }
}
