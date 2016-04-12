using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour {

    private PlayerTest _playerScript;

    void Start()
    {
        _playerScript = GameObject.Find("Sphere").GetComponent<PlayerTest>();
    }

    void Update()
    {
        GetComponent<Text>().text = "Score : " + _playerScript.getScore;
    }

}
