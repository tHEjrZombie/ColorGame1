using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Explosion : MonoBehaviour
{
    Light2D light2D;

    public Color color;
    public float outerRadius;
    public float lightIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();

        light2D.color = color;
    }

    void FixedUpdate()
    {
        if (light2D.pointLightOuterRadius < (1f + outerRadius))
            light2D.pointLightOuterRadius += 0.1f;

        if (light2D.pointLightOuterRadius > (0.5f + lightIntensity))
            light2D.intensity -= 0.1f;

        if (light2D.intensity <= 0)
            Destroy(gameObject);
    }
}
