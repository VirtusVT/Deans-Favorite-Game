using UnityEngine;

public class TurretA : Turret
{
    private void Update()
    {
        ConstantlyDamageEnemies();
    }

    private void ConstantlyDamageEnemies()
    {
        foreach (Enemy enemy in enemiesInRange)
        {
            enemy.TakeDamage(damagePerSecond * Time.deltaTime);

            if (enemy.lifes <= 0)
            {
                killedEnemies.Add(enemy);
            }
        }

        foreach (Enemy enemy in killedEnemies)
        {
            enemiesInRange.Remove(enemy);
            enemy.Kill();
        }
        
        killedEnemies.Clear();
    }
}
