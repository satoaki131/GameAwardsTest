using UnityEngine;

public class Particle : MonoBehaviour {

    private float _count = 0.2f;

    void Start()
    {
    }

    void Update()
    {
        _count -= Time.deltaTime;
        if (_count < 0)
        {
            Destroy(gameObject);
        }
    }

}
