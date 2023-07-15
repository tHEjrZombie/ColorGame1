using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D RB2D;

    [SerializeField] int speed;

    // Start is called before the first frame update
    void Start()
    {
        Game.Instance.gameObjectsToDestroy.Add(gameObject);

        RB2D = GetComponent<Rigidbody2D>();

        RB2D.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<EnemyHealth>().DamageDealt(1);

            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        Game.Instance.gameObjectsToDestroy.Remove(gameObject);
    }
}
