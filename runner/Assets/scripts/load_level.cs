using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class load_level : MonoBehaviour{
    public string level_name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void gotoLevel(){
        SceneManager.LoadScene(level_name);
    }
}
