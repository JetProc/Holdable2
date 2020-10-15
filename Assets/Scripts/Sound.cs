using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Image myImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public bool isSoundon;
    void Start()
    {
        isSoundon = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onButtonDown()
    {
        if (isSoundon)
        {
            soundOff();
            isSoundon = false;
        }
        else
        {
            soundOn();
            isSoundon = true;
        }
    }
    public void soundOn()
    {
        myImage.sprite = soundOnSprite;
    }
    public void soundOff()
    {
        myImage.sprite = soundOffSprite;
    }
}
