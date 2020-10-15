using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlColors : MonoBehaviour
{
    public rotateMap rotatemap;
    public Earth earth;
    public Rigidbody2D rb;
    public contorlWalls contorlwalls;
    public Wall1 wall1;
    public Wall2 wall2;
    public Wall3 wall3;
    public Wall4 wall4;

    //한번 닿을 때마다 바뀌는 count수 (정적)
    public int redTime;
    public int yellowTime;
    public int blueTime;
    public int greenTime;

    //랜덤으로 바뀌는 count수 (동적)
    public int redcoolTime;
    public int yellowcoolTime;
    public int bluecoolTime;
    public int greencoolTime;

    public Text redT;
    public Text yellowT;
    public Text blueT;
    public Text greenT;

    public Transform loadingBarLeft;
    public Transform loadingBarRight;
    public bool pressLeftBtn;
    public bool pressRightBtn;
    public float currentAmountL;
    public float currentAmountR;


    void Start()
    {
        redT = redT.GetComponent<Text>();
        yellowT = yellowT.GetComponent<Text>();
        blueT = blueT.GetComponent<Text>();
        greenT = greenT.GetComponent<Text>();

        redcoolTime = 1;
        yellowcoolTime = 1;
        bluecoolTime = 1;
        greencoolTime = 1;
        redTime = redcoolTime;
        blueTime = bluecoolTime;
        yellowTime = yellowcoolTime;
        greenTime = greencoolTime;

        redT.text = redcoolTime.ToString();
        blueT.text = bluecoolTime.ToString();
        yellowT.text = yellowcoolTime.ToString();
        greenT.text = greencoolTime.ToString();


        pressLeftBtn = false;
        pressRightBtn = false;
        currentAmountL = 0;
        currentAmountR = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressLeftBtn == true)
        {

            if (currentAmountL < 2f)
            {
                currentAmountL += Time.deltaTime;
            }
            else
            {
                currentAmountL = 0;
                pressLeftBtn = false;
            }
            loadingBarLeft.GetComponent<Image>().fillAmount = 1 - (currentAmountL / 2f);
        }

        if (pressRightBtn == true)
        {

            if (currentAmountR < 2f)
            {
                currentAmountR += Time.deltaTime;
            }
            else
            {
                currentAmountR = 0;
                pressRightBtn = false;
            }
            loadingBarRight.GetComponent<Image>().fillAmount = 1 - (currentAmountR / 2f);
        }
    }



    public void countRed()
    {
        redT.fontSize = 260;
        redTime--;
        redT.text = redTime.ToString();
        Invoke("cts1", 0.06f);
    }
    public void countBlue()
    {
        blueT.fontSize = 260;
        blueTime--;
        blueT.text = blueTime.ToString();
        Invoke("cts2", 0.06f);

    }
    public void countYellow()
    {
        yellowT.fontSize = 260;
        yellowTime--;
        yellowT.text = yellowTime.ToString();
        Invoke("cts3", 0.06f);

    }
    public void countGreen()
    {
        greenT.fontSize = 260;
        greenTime--;
        greenT.text = greenTime.ToString();
        Invoke("cts4", 0.06f);

    }

    public void prBarLeft()
    {
        pressLeftBtn = true;
    }
    public void prBarRight()
    {
        pressRightBtn = true;
    }


    public void restart()
    {
        if (contorlwalls.active1 == false)
        { 
            wall1.transform.localScale = new Vector3(0.5f, 7.7f, 1f);

            contorlwalls.cr1.a = 255f / 255f;
            contorlwalls.w1.color = new Color(contorlwalls.w1.color.r, contorlwalls.w1.color.g, contorlwalls.w1.color.b, contorlwalls.cr1.a);

            redcoolTime = randnum();
            redTime = redcoolTime;
            redT.text = redcoolTime.ToString();
        }
        else
        {
            redT.text = "-";
        }

        if (contorlwalls.active2 == false)
        {
            wall2.transform.localScale = new Vector3(0.5f, 7.7f, 1f);

            contorlwalls.cr2.a = 255f / 255f;
            contorlwalls.w2.color = new Color(contorlwalls.w2.color.r, contorlwalls.w2.color.g, contorlwalls.w2.color.b, contorlwalls.cr2.a);

            bluecoolTime = randnum();
            blueTime = bluecoolTime;
            blueT.text = bluecoolTime.ToString();

        }
        else
        {
            blueT.text = "-";
        }

        if (contorlwalls.active3 == false)
        {
            wall3.transform.localScale = new Vector3(0.5f, 7.7f, 1f);
            
            contorlwalls.cr3.a = 255f / 255f;
            contorlwalls.w3.color = new Color(contorlwalls.w3.color.r, contorlwalls.w3.color.g, contorlwalls.w3.color.b, contorlwalls.cr3.a);

            greencoolTime = randnum();
            greenTime = greencoolTime;
            greenT.text = greencoolTime.ToString();
        }
        else
        {
            greenT.text = "-";
        }

        if (contorlwalls.active4 == false)
        {
            wall4.transform.localScale = new Vector3(0.5f, 7.7f, 1f);

            contorlwalls.cr4.a = 255f / 255f;
            contorlwalls.w4.color = new Color(contorlwalls.w4.color.r, contorlwalls.w4.color.g, contorlwalls.w4.color.b, contorlwalls.cr4.a);

            yellowcoolTime = randnum();
            yellowTime = yellowcoolTime;
            yellowT.text = yellowcoolTime.ToString();
        }
        else
        {
            yellowT.text = "-";
        }
    }

    public void cts1()
    {
        redT.fontSize = 200;
    }
    public void cts2()
    {
        blueT.fontSize = 200;
    }
    public void cts3()
    {
        yellowT.fontSize = 200;
    }
    public void cts4()
    {
        greenT.fontSize = 200;
    }

    public int selectLevel()
    {
        int randomnum=1;
        for (int i = 500; i >=0; i -= 10)
        {
            if(earth.score >= i)
            {
                randomnum = i / 10;
                return randomnum;
            }
        }
        return randomnum;
    }

    public int randnum()
    {
        int x=Random.Range(1,3);
        switch (selectLevel())
        {
            case 0:
                x = Random.Range(1, 3);
                break;
            case 1:
                x = Random.Range(1, 4);
                break;
            case 2:
                x = Random.Range(1, 5);
                break;
            case 3:
                x = Random.Range(1, 6);
                break;
            case 4:
                x = Random.Range(1, 7);
                break;
            case 5:
                x = Random.Range(2, 5);
                break;
            case 6:
                x = Random.Range(2, 6);
                break;
            case 7:
                x = Random.Range(2, 7);
                break;
            case 8:
                x = Random.Range(2, 8);
                break;
            case 9:
                x = Random.Range(2, 9);
                break;
            case 10:
                x = Random.Range(2, 10);
                break;
            case 11:
                x = Random.Range(2, 11);
                break;
            case 12:
                x = Random.Range(3, 7);
                break;
            case 13:
                x = Random.Range(3, 8);
                break;
            case 14:
                x = Random.Range(3, 9);
                break;
            case 15:
                x = Random.Range(3, 10);
                break;
            case 16:
                x = Random.Range(3, 11);
                break;
            case 17:
                x = Random.Range(3, 12);
                break;
            case 18:
                x = Random.Range(3, 13);
                break;
            case 19:
                x = Random.Range(3, 14);
                break;
            case 20:
                x = Random.Range(3, 15);
                break;
            case 21:
                x = Random.Range(4, 9);
                break;
            case 22:
                x = Random.Range(4, 10);
                break;
            case 23:
                x = Random.Range(4, 11);
                break;
            case 24:
                x = Random.Range(4, 12);
                break;
            case 25:
                x = Random.Range(4, 13);
                break;
            case 26:
                x = Random.Range(4, 14);
                break;
            case 27:
                x = Random.Range(4, 15);
                break;
            case 28:
                x = Random.Range(4, 16);
                break;
            case 29:
                x = Random.Range(4, 17);
                break;
            case 30:
                x = Random.Range(4, 18);
                break;
            case 31:
                x = Random.Range(4, 19);
                break;
            case 32:
                x = Random.Range(5, 11);
                break;
            case 33:
                x = Random.Range(5, 12);
                break;
            case 34:
                x = Random.Range(5, 13);
                break;
            case 35:
                x = Random.Range(5, 14);
                break;
            case 36:
                x = Random.Range(5, 15);
                break;
            case 37:
                x = Random.Range(5, 16);
                break;
            case 38:
                x = Random.Range(5, 17);
                break;
            case 39:
                x = Random.Range(5, 18);
                break;
            case 40:
                x = Random.Range(5, 19);
                break;
            case 41:
                x = Random.Range(5, 20);
                break;
            case 42:
                x = Random.Range(5, 21);
                break;
            case 43:
                x = Random.Range(5, 22);
                break;
            case 44:
                x = Random.Range(5, 23);
                break;
            case 45:
                x = Random.Range(5, 24);
                break;
            case 46:
                x = Random.Range(6, 13);
                break;
            case 47:
                x = Random.Range(6, 14);
                break;
            case 48:
                x = Random.Range(6, 15);
                break;
            case 49:
                x = Random.Range(6, 16);
                break;
            case 50:
                x = Random.Range(6, 17);
                break;
        }
        return x;
    }
}
