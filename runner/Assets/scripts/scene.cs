using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class scene : MonoBehaviour {
    public GameObject[] arr_cloud;
    public GameObject[] arr_building;
    public GameObject[] arr_plant;
    private int level;
    private int win_score;
    public float speed_cloud;
    public float speed_building;
    public float speed_plant;
    float reset_x_cloud;
    float reset_x_building;
    float reset_x_plant;
    public float die_x;
    GameObject cloud;
    GameObject building;
    GameObject plant;
    GameObject hero;
    GameObject score;
    GameObject g_level;
    GameObject g_begin_level;
    public GameObject[] g_spawner;

    void Awake()
    {
       
        level = PlayerPrefs.GetInt("level");
        win_score = (level - 1) * 200 + 1000;
        PlayerPrefs.SetInt("win_score", win_score);
        hero = GameObject.Find("hero");
        ChooseSprites();
        score = GameObject.Find("Score");
        g_level = GameObject.Find("level");
        g_begin_level = GameObject.Find("begin_level");
    }
    // Use this for initialization
    void Start () {
        score.GetComponent<Text>().text = string.Format("得分：0/{0}",win_score);
        g_level.GetComponent<Text>().text = string.Format("关卡：{0}", level);
        g_begin_level.GetComponent<Text>().text = string.Format("第 {0} 关", level);
        //speed_cloud = 1.0f;
        //speed_building = 1.5f;
        //speed_plant = 2.0f;
        Invoke("inactiveUI",1.0f);
        for (int i = 0; i < 3; i++)
        {
            g_spawner[i].GetComponent<Spawner>().spawnTime *= (float)Math.Pow(0.9,(level - 1));
            Debug.Log(string.Format("{0},{1}", g_spawner[i].GetComponent<Spawner>().spawnTime, level));
        }
    }

    private void inactiveUI()
    {
        g_begin_level.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        
	}

    void FixedUpdate()
    {
        MoveSprites();

    }
    GameObject chooseOne(GameObject[] sprites,ref float rest_x)
    {
        int index =  UnityEngine.Random.Range(0, sprites.Length);
        if (sprites[index].transform.position.x == rest_x)
        {
            return chooseOne(sprites, ref rest_x);
        }
        else
        {
            rest_x = sprites[index].transform.position.x;
            return sprites[index];
        }
    }
    void ChooseSprites()
    {
        cloud = chooseOne(arr_cloud,ref reset_x_cloud);
        building = chooseOne(arr_building,ref reset_x_building);
        plant = chooseOne(arr_plant,ref reset_x_plant);
    }
    void MoveSprites()
    {
        MoveSprite(arr_cloud, ref cloud, speed_cloud,ref reset_x_cloud);
        MoveSprite(arr_building, ref building, speed_building,ref reset_x_building);
        MoveSprite(arr_plant,ref plant, speed_plant,ref reset_x_plant);
    }
    void MoveSprite(GameObject[] arr,ref GameObject sprite,float speed,ref float reset_x)
    {
        //Debug.Log("" + hero.GetComponent<Rigidbody2D>().velocity.x);
        float viewport_x = Camera.main.WorldToViewportPoint(sprite.transform.parent.position + sprite.transform.position).x;
        //Debug.Log("" + viewport_x);
        if (viewport_x < die_x)
        {
            Vector3 tmp = sprite.transform.position;
            tmp.x = reset_x;
            sprite.transform.position = tmp;
            sprite = chooseOne(arr,ref reset_x);

        }
        else
        {
            float speed_x = (((level * 0.1f) + 1) * speed-hero.GetComponent<Rigidbody2D>().velocity.x) * Time.deltaTime;
            sprite.transform.Translate(speed_x, 0, 0);
        }
    }
}
