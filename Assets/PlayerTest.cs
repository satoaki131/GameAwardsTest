using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private GameObject _Tornado = null;

    [SerializeField, Range(0.1f, 1.0f)]
    private float _speed = 0.5f;

    [SerializeField]
    private GameObject _particle = null;

    public Vector3 getPos
    {
        get { return transform.localPosition; }
    }

    static float _x = 0.0f;
    public static float getX
    {
        get { return _x; }
    }
    static float _z = 0.0f;
    public static float getZ
    {
        get { return _z; }
    }
    [SerializeField]
    private float _count = 1.0f;

    //[SerializeField]
    private bool[] _flug;

    private static int _score = 0;
    public int getScore
    {
        get { return _score; }
    }

    void Start()
    {
        _flug = new bool[5];
    }

    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        transform.localRotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.Translate(_x * _speed, 0, _z * _speed);

        if (_x == 1 && _z == 0 && !_flug[0])
        {
            _flug[0] = true;
            _count = 1.0f;
            Debug.Log("1");
            StartCoroutine(Wind());
        }

        if (_x == 0 && _z == 1 && _flug[0] && !_flug[1])
        {
            _flug[1] = true;
            _count = 1.0f;
            Debug.Log("2");
        }

        if (_x == -1 && _z == 0 && _flug[1] && !_flug[2])
        {
            _flug[2] = true;
            _count = 1.0f;
            Debug.Log("3");
        }

        if (_x == 0 && _z == -1 && _flug[2] && !_flug[3])
        {
            _flug[3] = true;
            _count = 1.0f;
            Debug.Log("4");
        }

        if (_flug[0] && _flug[1] && _flug[2] && _flug[3])
        {
            _flug[4] = true;
        }

        if (_flug[4])
        {
            var Tornado = Instantiate(_Tornado, transform.localPosition, Quaternion.identity) as GameObject;
            Tornado.name = "Tornado";
            Debug.Log("OK");
            var list = FindObjectOfType<CubeCreater>().list;
            for (int i = 0; i < 5; i++)
            {
                _flug[i] = false;
            }
            foreach (var i in list)
            {
                i.GetComponent<Point>().isFlug = true;
            }
        }
    }

    IEnumerator Wind()
    {
        while (true)
        {
            _count -= Time.deltaTime;
            if (_count < 0)
            {
                _count = 1.0f;
                break;
            }
            yield return null;
        }
        for (int i = 0; i < 4; i++)
        {
            _flug[i] = false;
        }
        yield return null;

    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Cube")
        {
            _score++;
            //Debug.Log("Score : " + _score);
        }
    }
}
