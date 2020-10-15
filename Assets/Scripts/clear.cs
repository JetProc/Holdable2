using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public ParticleSystem clearPariticle;
    public controlColors controlcolors;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goNext()
    {
        controlcolors.restart();
        clearPariticle.Play();
    }


}
