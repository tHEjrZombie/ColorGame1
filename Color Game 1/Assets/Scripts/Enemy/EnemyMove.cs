using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static float enemyMoveSpeed;

    [SerializeField] float thisEnemySpeed;

    void Start()
    {
        Game.Instance.gameObjectsToDestroy.Add(gameObject);

        thisEnemySpeed = enemyMoveSpeed;

        thisEnemySpeed = Random.Range(thisEnemySpeed - 0.5f, thisEnemySpeed + 0.5f);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, enemyMoveSpeed * Time.fixedDeltaTime);
    }
}
