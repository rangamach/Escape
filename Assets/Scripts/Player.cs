using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float move_speed; // speed player moves.
    [SerializeField] private Rigidbody2D rigidbody_2d; 
    [SerializeField] private Animator animator;
    [SerializeField] private HUD hud;
    private Vector2 movement; // input speed.
    private Vector3 rotation = new Vector3(); // rotation of player faces

    [SerializeField] private int number_of_keys;
    private int collected_keys;

    private void Awake()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
        rotation = Vector3.zero;
        collected_keys = 0;
        hud.UpdateText(0);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //sets the animator parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //orients player correctly.
            rotation.y = 180f;
            gameObject.transform.eulerAngles = rotation;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //orients player correctly.
            rotation.y = 0f;
            gameObject.transform.eulerAngles = rotation;
        }  
    }

    void FixedUpdate()
    {
        //actually moves player.
        rigidbody_2d.MovePosition(rigidbody_2d.position + movement * move_speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            GetComponent<Pause>().EnableGameOverCanvas();
            AudioManager.Instance.PlayAudioEffect(AudioTypes.EnemyHit);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Key>())
        {
            collected_keys++;
            AudioManager.Instance.PlayAudioEffect(AudioTypes.Key);
            hud.UpdateText(collected_keys);
            Destroy(collision.gameObject);
            if (collected_keys == number_of_keys)
                collision.GetComponent<Key>().DoorAnimation();
        }
    }
}
