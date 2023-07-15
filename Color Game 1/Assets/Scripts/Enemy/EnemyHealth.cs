using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamageDealt(health);
            GetComponent<EnemyVariety>().touchingPlayer = true;

            Destroy(gameObject);
        }
    }

    public void DamageDealt(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {
            if (Game.timerCap > 1)
                Game.timerCap--;

            EnemyMove.enemyMoveSpeed += 0.05f;
            Game.Instance.Score(1);
            Destroy(gameObject);
        }
    }
    
    public void HealthGained(int gain)
    {
        health += gain;
    }

    void OnDestroy()
    {
        Game.Instance.gameObjectsToDestroy.Remove(gameObject);
    }
}
