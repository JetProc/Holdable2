using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateMap : MonoBehaviour
{
    public Earth earth;
    public Rigidbody2D earthRb;
    public EndGame endgame;

    public GameObject Grounds;

    public float turnSpeed=0f;
    public float tSpeed;

    public Text countL;
    public Text L;
    public Text countR;
    public Text R;

    private void Start()
    {
        tSpeed = 100f;
    }
    public void Update()
    {
        if (turnSpeed > 0)
        {
            turnSpeed = tSpeed;
        }
        else if (turnSpeed < 0)
        {
            turnSpeed = -tSpeed;
        }
        if (endgame.isdie == false)
        {
            if (endgame.isGameStart == true)
            {
                Grounds.transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            }
        }

        if (turnSpeed != 0f)
        {
            earthRb.gravityScale = 1f;
        }
    }
    public void turnright()
    {
        if (earth.timeCountRight == 2)
        {
            countR.fontSize = 130;
            R.fontSize = 300;
            Invoke("textSizeR", 0.1f);
            turnSpeed = -tSpeed;
        }
    }
    public void turnleft()
    {


        if (earth.timeCountLeft == 2)
        {
            countL.fontSize = 130;
            L.fontSize = 300;
            Invoke("textSizeL", 0.1f);
            turnSpeed = tSpeed;
        }
    }
    public void textSizeL()
    {
        countL.fontSize = 100;
        L.fontSize = 250;
    }
    public void textSizeR()
    {
        countR.fontSize = 100;
        R.fontSize = 250;
    }
}
