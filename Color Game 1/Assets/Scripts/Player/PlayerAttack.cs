using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject pressW;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform barrel;

    public void Attack(InputAction.CallbackContext context) 
    {
        if (context.canceled)
            if (PlayerHealth.Instance.health > 0)
                Instantiate(projectile, barrel.position, barrel.rotation);

        if (pressW.activeInHierarchy)
        {
            Time.timeScale = 1;

            pressW.SetActive(false);
        }
    }
}
