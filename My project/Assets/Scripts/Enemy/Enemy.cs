using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float lifes;
    
    [Header("Pathfinding")]
    [SerializeField] public Transform[] waypoints;
    [SerializeField] public float moveSpeed = 2f;
    
    private int waypointIndex = 0;
    private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update () {
        Move();
    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        lifes -= damage;
    }
    
    public void Kill()
    {
        Destroy(gameObject);
    }
}
