using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBtn : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb.AddForce(new Vector2(200, 150));
    }
}
