using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class remover : MonoBehaviour {
    public GameObject splash;
    private GameObject tip_ui;
    private int level;
    void Awake()
    {
        // Setting up the reference.
        tip_ui = GameObject.Find("begin_level");
        level = PlayerPrefs.GetInt("level");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
          
            // .. stop the Health Bar following the player
            if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
            {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
            }

            // ... destroy the player.
            Destroy(col.gameObject);
            // ... reload the level.
            StartCoroutine("ReloadGame");
        }
        else
        
            Destroy(col.gameObject);
    }

    IEnumerator ReloadGame()
    {
        tip_ui.GetComponent<Text>().text = string.Format("闯关失败，当前记录第{0}关！", level);
        tip_ui.SetActive(true);
        // ... pause briefly
        yield return new WaitForSeconds(2);
        // ... and then reload the level.
        SceneManager.LoadScene("start");
    }
}
