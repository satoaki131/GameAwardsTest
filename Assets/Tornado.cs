using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour
{

    void Start()
    {
    }


    void Update()
    {
        transform.Rotate(0, 1, 0);

        if (!Point.isTornadoFlug)
        {
            Destroy(gameObject);
        }

    }
}
