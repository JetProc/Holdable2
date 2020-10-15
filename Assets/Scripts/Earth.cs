using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour
{
    public Sound sound;
    public GameObject earth;
    public Rigidbody2D rb;

    public rotateMap rotatemap;

    public int score;
    public Text scoreT;
    /*public Text coolTimeZero;
    public Text coolTimeOne;*/
    public Text coolTimeLeft;
    public Text coolTimeRight;

    /*public float timeCountZero;
    public float timeCountOne;*/
    public float timeCountLeft;
    public float timeCountRight;

   /* public bool isClickedZero;
    public bool isClcikedOne;*/
    public bool isClickedLeft;
    public bool isClickedRight;

    //1은 enter, 2는 exit
    public int tagWall1;
    public int tagWall2;
    public int tagWall3;
    public int tagWall4;


    public Vector3 wall1Pos;
    public Vector3 wall2Pos;
    public Vector3 wall3Pos;
    public Vector3 wall4Pos;

    public AudioSource ef2;
    public AudioClip bounceSound;
    private void Awake()
    {
       /// Time.timeScale = 1;
    }
    void Start()
    {
        score =0;
        scoreT = scoreT.GetComponent<Text>();

        coolTimeLeft.GetComponent<Text>();
        coolTimeRight.GetComponent<Text>();
        /*isClickedZero = false;
        isClcikedOne = false;*/
        isClickedLeft = false;
        isClickedRight = false;
        /*timeCountZero = 5;
        timeCountOne = 10;*/
        timeCountLeft = 2;
        timeCountRight = 2;

        coolTimeLeft.text = string.Format("{0:N1}", timeCountLeft);
        coolTimeRight.text = string.Format("{0:N1}", timeCountRight);
        tagWall1 = 0;
        tagWall2 = 0;
        tagWall3 = 0;
        tagWall4 = 0;

        ef2 = ef2.GetComponent<AudioSource>();
        ef2.clip = bounceSound;
    }
    public void playSound()
    {
        ef2.PlayOneShot(bounceSound);
    }
    void Update()
    {
        if (sound.isSoundon == true)
        {
            ef2.mute = false;
        }
        else
        {
            ef2.mute = true;
        }
        /*if (isClickedZero == true)
        {
            if (timeCountZero > 0)
            {
                timeCountZero -= Time.deltaTime;
            }
            else
            {
                rb.gravityScale = 1;
                timeCountZero = 5;
                isClickedZero = false;
            }
        }
        if (isClcikedOne == true)
        {
            if (timeCountOne > 0)
            {
                timeCountOne -= Time.deltaTime;
            }
            else
            {
                if (rb.gravityScale != 0)
                rb.gravityScale = 1;
                timeCountOne = 10;
                isClcikedOne = false;
            }
        }*/
        if (isClickedLeft == true)
        {
            if (timeCountLeft > 0)
                timeCountLeft -= Time.deltaTime;
            else
            {
                timeCountLeft = 2;
                isClickedLeft = false;
            }
        }
        if (isClickedRight == true)
        {
            if (timeCountRight > 0)
                timeCountRight -= Time.deltaTime;
            else
            {
                timeCountRight = 2;
                isClickedRight = false;
            }
        }

        
            coolTimeLeft.text = string.Format("{0:N1}", timeCountLeft);
        
        
            coolTimeRight.text = string.Format("{0:N1}", timeCountRight);
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall1")
        {
            playSound();
            wall1Pos = collision.contacts[0].point;
           //     Debug.Log("TAGWALL1");
                tagWall1 = 1;
        }
        else tagWall1 = 0;

        if (collision.gameObject.tag == "Wall2")
        {
            playSound();
            wall2Pos = collision.contacts[0].point;
         //   Debug.Log("TAGWALL2");
            tagWall2 = 1;
        }
        else tagWall2 = 0;

        if (collision.gameObject.tag == "Wall3")
        {
            playSound();
            wall3Pos = collision.contacts[0].point;
            //    Debug.Log("TAGWALL3");
            tagWall3 = 1;

        }
        else tagWall3 = 0;

        if (collision.gameObject.tag == "Wall4")
        {
            playSound();
            wall4Pos = collision.contacts[0].point;
            //  Debug.Log("TAGWALL4");
            tagWall4 = 1;

        }
        else tagWall4 = 0;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall1")
        {
          //  Debug.Log("TAGWALL1");
            tagWall1 = 2;
        }
        else tagWall1 = 0;

        if (collision.gameObject.tag == "Wall2")
        {
         //   Debug.Log("TAGWALL2");
            tagWall2 = 2;
        }
        else tagWall2 = 0;
        
        if (collision.gameObject.tag == "Wall3")
        {
         //   Debug.Log("TAGWALL3");
            tagWall3 = 2;
        }
        else tagWall3 = 0;

        if (collision.gameObject.tag == "Wall4")
        {
        //    Debug.Log("TAGWALL4");
            tagWall4 = 2;
        }
        else tagWall4 = 0;
    }


    /*public void gravity()
    {
        if(isClcikedOne==false)
        rb.gravityScale = -1;
    }
    public void reverseGravity()
    {
        if (isClickedZero == false)
        rb.gravityScale = 0;
    }

    public void cooltimeZero()
    {
        isClickedZero = true;
    }
    public void cooltimeOne()
    {
        isClcikedOne = true;
    }*/
    public void cooltimeLeft()
    {
        isClickedLeft = true;
    }
    public void cooltimeRight()
    {
        isClickedRight = true;
    }
}
