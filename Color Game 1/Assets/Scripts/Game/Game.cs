using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] GameObject pressEnter;
    [SerializeField] GameObject enemy;

    public List<GameObject> gameObjectsToDestroy = new List<GameObject>();

    public static int score;
    public static int timerCap;

    int timer;

    int randX, randY;
    float x, y;

    void Awake()
    {
        Instance = this;

        Time.timeScale = 0;

        EnemyMove.enemyMoveSpeed = 1f;

        timerCap = 100;
    }

    void FixedUpdate()
    {
        timer++;

        if (timer > timerCap)
        {
            randX = Random.Range(1, 3);
            randY = Random.Range(1, 3);

            if (randX == 1)
                x = Random.Range(9.0f, 18.25f);
            else if (randX == 2)
                x = Random.Range(-9.0f, -18.25f);

            if (randY == 1)
                y = Random.Range(6.25f, 17.5f);
            else if (randY == 2)
                y = Random.Range(-6.25f, -17.5f);

            Instantiate(enemy, new Vector2(x, y), transform.rotation);

            timer = 0;
        }
    }

    public void Enter(InputAction.CallbackContext context)
    {
        if (PlayerHealth.Instance.health <= 0)
        {
            Time.timeScale = 1;
            pressEnter.SetActive(false);
            PlayerHealth.Instance.health = 10;
            PlayerHealth.Instance.DamageDealt(0);
            score = 0;
            Score(0);
            timerCap = 100;

            foreach (GameObject enemyGO in gameObjectsToDestroy)
                Destroy(enemyGO);

            EnemyMove.enemyMoveSpeed = 1;

            gameObjectsToDestroy.Clear();
        }
    }

    public void Score(int add) 
    {
        score += add;
        scoreTxt.text = "Score = " + score;
    }
}
