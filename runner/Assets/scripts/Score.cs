using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.
    private int win_score;
    private GameObject tip_ui;
    private int level;

	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        tip_ui = GameObject.Find("begin_level");
        level = PlayerPrefs.GetInt("level");
	}
    void Start()
    {
        win_score = PlayerPrefs.GetInt("win_score");
    }

	void Update ()
	{
        GetComponent<Text>().text = "得分: " + score+"/"+PlayerPrefs.GetInt("win_score");

		// If the score has changed...
		if(previousScore != score)
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());

		// Set the previous score to this frame's score.
		previousScore = score;
        if (score >= win_score)
        {
            tip_ui.GetComponent<Text>().text = "恭喜，闯关成功！";
            tip_ui.SetActive(true);
            Invoke("gotoNextLevel", 2);
            
        }

	}
    void gotoNextLevel()
    {
        PlayerPrefs.SetInt("level", level + 1);
        SceneManager.LoadScene("game");
    }

}
