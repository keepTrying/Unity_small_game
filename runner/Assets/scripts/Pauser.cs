using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pauser : MonoBehaviour {
	private bool paused = false;
    public Text text;
    AudioSource audioSource;
    GameObject back;
    GameObject panel;
	// Update is called once per frame
	void Update () {
	

		
	}
    void Awake()
    {
        GameObject music = GameObject.Find("music");
        audioSource = music.GetComponent<AudioSource>();
        back = GameObject.Find("Back");
        panel = GameObject.Find("Panel");       
    }
    public void Click()
    {
       

        if (!paused)
        {
            Time.timeScale = 0;
            text.text = "继续";
            audioSource.Pause();
            back.SetActive(false);
            panel.SetActive(false);


        }
        else
        {
            Time.timeScale = 1;
            text.text = "暂停";
            audioSource.Play();
            back.SetActive(true);
            panel.SetActive(true);
        }
        paused = !paused;
    }
}
