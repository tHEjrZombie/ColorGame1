using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponPivot : MonoBehaviour
{
    void Update()
    {
        RotateToTarget();
    }

    void RotateToTarget()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var offset = -90f;
        Vector2 direction = (mousePosition - new Vector2(transform.position.x, transform.position.y));
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * (angle + offset)), 20);// 1
    }
}
