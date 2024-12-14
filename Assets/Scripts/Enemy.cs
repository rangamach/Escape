using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2.0f; // Speed of the patrol
    [SerializeField] private float waitTime = 2.0f; // Time to wait at each waypoint
    [SerializeField] private Transform[] waypoints; // Array to hold the waypoints
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isWaiting = false; // To track if the enemy is currently waiting
    private Vector3 rotation = Vector3.zero;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            StartCoroutine(Patrol());
        }
    }
    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isWaiting)
            {
                MoveTowardsWaypoint();
                // Check if the enemy has reached the waypoint
                if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
                {
                    StartCoroutine(WaitAtWaypoint());
                }
            }
            yield return null; // Wait for the next frame
        }
    }
    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
            return;
        // Calculate the direction to the current waypoint
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        float step = speed * Time.deltaTime; // Move speed per frame
        // Move the enemy towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, step);
        // Flip the enemy to face the direction of movement
        FlipEnemy(direction);
    }
    void FlipEnemy(Vector3 direction)
    {
        if (direction.magnitude > 0.01f) // If moving
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Adjust the angle if needed
            //if (direction.y == 1)
            if (angle > 89 && angle < 92)
            {
                animator.Play("enemy_walk_back");
            }
            //else if (direction.y == -1)
            else if (angle < 91 && angle > 88 || angle > -91 && angle < -88)
            {
                animator.Play("enemy_walk_front");
            }
            //else if(direction.x == 1)
            else if (angle > -1 && angle < 1)
            {
                rotation.y = 0f;
                gameObject.transform.eulerAngles = rotation;
                animator.Play("enemy_walk_right");
            }
            //else if(direction.x == -1)
            else if (angle > 179 && angle < 181 || angle > -181 && angle < -179)
            {
                rotation.y = 180f;
                gameObject.transform.eulerAngles = rotation;
                animator.Play("enemy_walk_right");
            }

        }
    }
    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        animator.Play("enemy_idle");
        yield return new WaitForSeconds(waitTime); // Wait for the specified time
        isWaiting = false;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Move to the next waypoint
    }
}
