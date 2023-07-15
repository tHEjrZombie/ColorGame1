using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] GameObject pressEnter;
    [SerializeField] TextMeshProUGUI healtTxt;

    public int health;

    void Awake()
    {
        Instance = this;

        health = 10;
    }

    public void DamageDealt(int damage)
    {
        health -= damage;

        healtTxt.text = "Health = " + health;

        if (health <= 0) 
        {
            pressEnter.SetActive(true);
            Time.timeScale = 0;
        } 
    }

    public void HealthGained(int gain)
    {
        health += gain;

        healtTxt.text = "Health = " + health;
    }
}
