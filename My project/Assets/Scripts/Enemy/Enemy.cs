using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float lifes;
    [SerializeField] public Transform lifeBarTransform;
    
    [Header("Pathfinding")]
    [SerializeField] public Transform[] waypoints;
    [SerializeField] public float moveSpeed = 2f;
    
    private int waypointIndex = 0;
    private float maxLifes;
    private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
        maxLifes = lifes;
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

    private void UpdateLifeBar()
    {
        lifeBarTransform.localScale = new Vector3(math.remap(0, maxLifes, 0, 1, lifes), 1 , 1);
    }

    public void TakeDamage(float damage)
    {
        lifes -= damage;
        UpdateLifeBar();
    }
    
    public void Kill()
    {
        Destroy(gameObject);
    }
}
