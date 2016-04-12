using UnityEngine;
using System.Collections.Generic;

public class CubeCreater : MonoBehaviour {

    [SerializeField]
    private GameObject _obj;

    private List<GameObject> _list = null;
    public List<GameObject> list
    {
        get { return _list; }
    }
    void Start ()
    {
        _list = new List<GameObject>();
	    for(int i = 0; i < 8; i++)
        {
            var obj = Instantiate(_obj, 
                new Vector3(Random.Range(-25.0f, 25.0f), 1.0f, Random.Range(-25.0f, 25.0f)),
                Quaternion.identity) as GameObject;
            obj.transform.parent = transform;
            obj.name = "Cube";
            _list.Add(obj);
        }
	}
	
	void Update ()
    {
        for (int i = 0; i < 8; i++)
        {
            if(_list[i] == null)
            {
                _list[i] = Instantiate(_obj,
                new Vector3(Random.Range(-25.0f, 25.0f), 1.0f, Random.Range(-25.0f, 25.0f)),
                Quaternion.identity) as GameObject;
                _list[i].transform.parent = transform;
                _list[i].name = "Cube";
            }
        }

    }
}
