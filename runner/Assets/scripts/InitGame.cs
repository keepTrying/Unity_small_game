using UnityEngine;
using System.Collections;

public class InitGame : MonoBehaviour {
    void Awake()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("win_score", 1000);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
