using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mulai()
    {
        anim.SetTrigger("open2");
    }

    public void baca()
    {
        anim.SetTrigger("open3");
    }
    public void huruf()
    {
        anim.SetTrigger("open3");
    }
    public void kata()
    {
        anim.SetTrigger("open3");
    }

    public void back()
    {
        anim.SetTrigger("back");
    }
}
