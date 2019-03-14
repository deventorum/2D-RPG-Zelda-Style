using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    Animator anim;
    public Image[] Hearts;
    public int maxHealth;
    int currentHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("dir", 0);
        currentHealth = maxHealth;

        GetHealth();
    }

    void GetHealth()
    {
        for (int i = 0; i < currentHealth; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Debug.Log(Hearts[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        RunPlayerAnimation();
    }

    private void RunPlayerAnimation()
    {
        anim.speed = 1;
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetInteger("dir", 3);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetInteger("dir", 4);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetInteger("dir", 1);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetInteger("dir", 2);
        }
        else
        {
            anim.speed = 0;
        }
    }
}
