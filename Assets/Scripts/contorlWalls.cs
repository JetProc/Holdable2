using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contorlWalls : MonoBehaviour
{
    public controlColors controlcolors;
    public clear clear;
    public Rigidbody2D rb;
    public bool clearAll;
    public bool clear1;
    public bool clear2;
    public bool clear3;
    public bool clear4;
    
    public bool active1;
    public bool active2;
    public bool active3;
    public bool active4;

    public SpriteRenderer w1;
    public SpriteRenderer w2;
    public SpriteRenderer w3;
    public SpriteRenderer w4;

    public Wall1 wall1;
    public Wall2 wall2;
    public Wall3 wall3;
    public Wall4 wall4;

    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;

    public Color cr1;
    public Color cr2;
    public Color cr3;
    public Color cr4;

    public Earth earth;
    public rotateMap rotatemap;
    public Text myscore;

    public int count1;
    public int count2;
    public int count3;
    public int count4;
    public int tempColor;
    public float timer;
    public int randomColor;
    public int colorScale;

    public bool isChange;

    void Awake()
    {
    }
    void Start()
    {
        myscore = myscore.GetComponent<Text>();
        clearAll = false;
        clear1 = false;
        clear2 = false;
        clear3 = false;
        clear4 = false;

        active1 = false;
        active2 = false;
        active3 = false;
        active4 = false;

        colorScale = 45;
        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        timer = -2;
        isChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        ///tagwall==1은 닿았을 때 (enter)
        //red
        if (earth.tagWall1 == 1)
        {
            if (controlcolors.redTime <= 1)
            {
                clear1 = true;
                isClear();
                wall1.transform.localScale = new Vector3(0.3f+(0.2f*controlcolors.redTime), 7.7f,1f);
                cr1.a -= 70/255f;
                w1.color = new Color(w1.color.r, w1.color.g, w1.color.b, cr1.a);

                if (controlcolors.redTime <= -2)
                {
                    wall1.gameObject.SetActive(false);
                    active1 = true;
                }
            }
            count1++;
            changeScore(controlcolors.redTime);
            p1.transform.position = earth.wall1Pos;
            p1.Play();

            earth.tagWall1 = 0;

            controlcolors.countRed();
        }
        //blue
        if (earth.tagWall2 == 1)
        {
            if (controlcolors.blueTime <= 1)
            {
                clear2 = true;
                isClear();
                wall2.transform.localScale = new Vector3(0.3f + (0.2f * controlcolors.blueTime), 7.7f, 1f);
                cr2.a -= 70 / 255f;
                w2.color = new Color(w2.color.r, w2.color.g, w2.color.b, cr2.a);

                if (controlcolors.blueTime <= -2)
                {
                    wall2.gameObject.SetActive(false);
                    active2 = true;
                }
            }
            count2++;
            changeScore(controlcolors.blueTime);
            p2.transform.position = earth.wall2Pos;
            p2.Play();

            earth.tagWall2 = 0;

            controlcolors.countBlue();
        }
        //green
        if (earth.tagWall3 == 1)
        {
            if (controlcolors.greenTime <= 1)
            {
                clear3 = true;
                isClear();
                wall3.transform.localScale = new Vector3(0.3f + (0.2f * controlcolors.greenTime), 7.7f, 1f);
                cr3.a -= 70 / 255f;
                w3.color = new Color(w3.color.r, w3.color.g, w3.color.b, cr3.a);

                if (controlcolors.greenTime <= -2)
                {
                    wall3.gameObject.SetActive(false);
                    active3 = true;
                }
            }
            count3++;
            changeScore(controlcolors.greenTime);
            p3.transform.position = earth.wall3Pos;
            p3.Play();
            
            earth.tagWall3 = 0;

            controlcolors.countGreen();
        }
        //yellow
        if (earth.tagWall4 == 1)
        {
            if (controlcolors.yellowTime <= 1)
            {
                clear4 = true;
                isClear();
                wall4.transform.localScale = new Vector3(0.3f + (0.2f * controlcolors.yellowTime), 7.7f, 1f);
                cr4.a -= 70 / 255f;
                w4.color = new Color(w4.color.r, w4.color.g, w4.color.b, cr4.a);

                if (controlcolors.yellowTime <= -2 )
                {
                    wall4.gameObject.SetActive(false);
                    active4 = true;
                }
            }
            count4++;
            changeScore(controlcolors.yellowTime);
            p4.transform.position = earth.wall4Pos;
            p4.Play();
            earth.tagWall4 = 0;

            controlcolors.countYellow();
        }
        ///tagwall==2는 뗐을 때(exit)
        if (earth.tagWall1 == 2)
        {
            earth.tagWall1 = 0;
        }
        if (earth.tagWall2 == 2)
        {
            earth.tagWall2 = 0;
        }
        if (earth.tagWall3 == 2)
        {
            earth.tagWall3 = 0;
        }
        if (earth.tagWall4 == 2)
        {
            earth.tagWall4 = 0;
        }

        

        

        

        

        if (clearAll == true) {
            if(active1==false)
            clear1 = false;
            if(active2==false)
            clear2 = false;
            if(active3==false)
            clear3 = false;
            if(active4==false)
            clear4 = false;
            
            
            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;

            clear.goNext();
            clearAll = false;
        }
    }

    public void isClear()
    {
        if (clear1 == true && clear2 == true && clear3 == true && clear4 == true)
        {
            clearAll = true;
        }
    }

    public void changeScore(int t)
    {
        if (t >0)
        {
            myscore.fontSize = 300;
            earth.score += 1;
            
            if (earth.score >= 100)
            {
                rotatemap.tSpeed = 140f ;
            }
            else if (earth.score >= 50)
            {
                rotatemap.tSpeed = 115f;
            }
            earth.scoreT.text = earth.score.ToString();
            Invoke("changeSize", 0.03f);
        }
    }

    public void changeSize()
    {
        myscore.fontSize = 240;
    }
}
