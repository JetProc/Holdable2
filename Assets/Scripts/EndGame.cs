using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text red;
    public Text blue;
    public Text green;
    public Text yellow;

    public Text currentscore;
    public Text highscore;
    public int currentscore_int;
    public int highscore_int;

    public Earth earthscript;
    public ParticleSystem dieParticle;

    public bool isGameStart;
    public GameObject earth;
    public GameObject walls;
    public Vector3 pos;
    public Canvas canvas;
    public Vector3 diePos;

    public bool isdie;

    void Awake()
    {
        load();
    }
    void Start()
    {
        currentscore_int = 0;
        isdie = false;
        isGameStart = true;
        canvas = canvas.GetComponent<Canvas>();
        pos = Camera.main.WorldToViewportPoint(earth.transform.position);

    }

    void Update()
    {


        pos = Camera.main.WorldToViewportPoint(earth.transform.position);
        if (isdie == false)
        {
            if (pos.x > 1 || pos.x < 0 || pos.y > 1 || pos.y < 0)
            {
                isdie = true;
                if (isdie == true)
                {
                    diePos = earth.gameObject.transform.position;
                    diePc();
                }
                Invoke("restart", 3);
            }
        }
        else
        {
            earth.gameObject.SetActive(false);
            earth.gameObject.transform.position = diePos;
        }
    }
    public void retryBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void changeT()
    {
        Time.timeScale = 1;
    }

    public void restart()
    {
        canvas.gameObject.SetActive(true);
    }
    public void diePc()
    {
        earth.gameObject.transform.position = diePos;
        dieParticle.gameObject.transform.position = earth.gameObject.transform.position;
        dieParticle.Play();
        
        currentscore_int = earthscript.score;
        if (currentscore_int > highscore_int)
        {
            highscore_int = currentscore_int;
            save();
        }
        highscore.text = highscore_int.ToString();
        currentscore.text = currentscore_int.ToString();
    }

    public void save()
    {
        PlayerPrefs.SetInt("Highscore",highscore_int);
    }
    public void load()
    {
        highscore_int = PlayerPrefs.GetInt("Highscore");
    }
}
