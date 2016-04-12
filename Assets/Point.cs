using UnityEngine;
using System.Collections;
using System;

public class Point : MonoBehaviour
{
    private PlayerTest _playerScript;
    private Vector3 _playerPos;

    public bool isFlug
    {
        set; get;
    }

    public static bool isTornadoFlug
    {
        set; get;
    }

    [SerializeField, Range(50, 1000)]
    private int _power = 100;

    void Start()
    {
        _playerScript = GameObject.Find("Sphere").GetComponent<PlayerTest>();
        isTornadoFlug = false;
    }

    void Update()
    {
        if(isFlug)
        {
            isTornadoFlug = true;
            StartCoroutine(WindStart());
            _playerPos = _playerScript.getPos;
            isFlug = false;
        }
    }

    private int _speed = 0;

    private float _count = 5.0f;

    private IEnumerator WindStart()
    {
        while(true)
        {
            _count -= Time.deltaTime;
            var localRotation = transform.localRotation;
            Vector3 movePos = Vector3.Normalize(_playerPos - transform.localPosition);
            //transform.Translate(movePos * 0.1f);
            var localPosition = transform.localPosition;
            localPosition += movePos * 0.1f;
            transform.localPosition = localPosition;
            _speed++;
            localRotation = Quaternion.Euler(0, _speed, 0);
            transform.localRotation = localRotation;
            if(_count < 0.0f)
            {
                _count = 5.0f;
                Destroy(gameObject);
                isTornadoFlug = false;
                break;
            }
            yield return null;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Sphere")
        {
            transform.localRotation = Quaternion.Euler(Vector3.up * 50);
            GetComponent<Rigidbody>().AddForce(Vector3.up * _power / 1.5f);
            if(PlayerTest.getX < 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.left * _power);
            }
            else if(PlayerTest.getX > 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * _power);
            }
            
            if(PlayerTest.getZ < 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.back * _power);
            }
            else if(PlayerTest.getZ > 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.forward * _power);
            }
            StartCoroutine(test());
        }
    }

    private IEnumerator test()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
