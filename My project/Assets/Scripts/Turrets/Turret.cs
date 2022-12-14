using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    [SerializeField] public int level;
    [SerializeField] public float damagePerSecond;
    [SerializeField] public List<Enemy> enemiesInRange;
    [SerializeField] public List<Enemy> killedEnemies;

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
            enemiesInRange.Add(col.gameObject.GetComponent<Enemy>());
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
            enemiesInRange.Remove(other.gameObject.GetComponent<Enemy>());
    }
}
