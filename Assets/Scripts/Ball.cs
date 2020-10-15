using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 wall1Pos;
    public Vector3 wall2Pos;
    public Vector3 wall3Pos;
    public Vector3 wall4Pos;

    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;

    void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall1")
        {
            wall1Pos = collision.contacts[0].point;
            //     Debug.Log("TAGWALL1");
            p1.transform.position = wall1Pos;
            p1.Play();
        }

        if (collision.gameObject.tag == "Wall2")
        {
            wall2Pos = collision.contacts[0].point;
            //   Debug.Log("TAGWALL2");
            p2.transform.position = wall2Pos;
            p2.Play();
        }

        if (collision.gameObject.tag == "Wall3")
        {
            wall3Pos = collision.contacts[0].point;
            //    Debug.Log("TAGWALL3");
            p3.transform.position = wall3Pos;
            p3.Play();
        }

        if (collision.gameObject.tag == "Wall4")
        {
            wall4Pos = collision.contacts[0].point;
            //  Debug.Log("TAGWALL4");
            p4.transform.position = wall4Pos;
            p4.Play();
        }
    }
}
