using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariety : MonoBehaviour
{
    SpriteRenderer SR;
    [SerializeField] GameObject explosion;

    bool isBrown;
    bool isBlack;
    [HideInInspector] public bool touchingPlayer;
    bool doNotInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        int rand = Random.Range(1, 9);

        switch (rand)
        {
            case 1:
                SR.color = Color.white;
                break;
            case 2:
                SR.color = Color.black;
                isBlack = true;
                break;
            case 3:
                SR.color = Color.green;
                break;
            case 4:
                SR.color = new Color(0.9882353f, 0.2745098f, 0.6666667f);//pink
                break;
            case 5:
                SR.color = new Color(0.6392157f, 0.172549f, 0.7686275f);//purple
                break;
            case 6:
                SR.color = Color.red;
                break;
            case 7:
                SR.color = Color.yellow;
                break;
            case 8:
                SR.color = new Color(0.3960784f, 0.2078431f, 0.05882353f);//brown
                isBrown = true;
                break;
            default:
                break;
        }

        if (rand == 8)
        {
            transform.localScale = new Vector2(1,1);
            GetComponent<EnemyHealth>().HealthGained(1);
        }
    }

    void OnDestroy()
    {
        if (!doNotInstantiate)
        {
            GameObject explosionGO = Instantiate(explosion, transform.position, transform.rotation);

            if (isBrown)
            {
                explosionGO.GetComponent<Explosion>().outerRadius = 2;
                explosionGO.GetComponent<Explosion>().lightIntensity = 1;
            }

            if (!touchingPlayer && !isBlack)
                explosionGO.GetComponent<Explosion>().color = SR.color;
            else if (!touchingPlayer && isBlack)
                explosionGO.GetComponent<Explosion>().color = Color.white;
            else
            {
                explosionGO.GetComponent<Explosion>().color = Color.blue;
                explosionGO.GetComponent<Explosion>().outerRadius = 3;
                explosionGO.GetComponent<Explosion>().lightIntensity = 1.5f;
            }
        }
    }

    void OnApplicationQuit()
    {
        doNotInstantiate = true;
    }
}
