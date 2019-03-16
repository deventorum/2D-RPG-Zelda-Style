using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    Animator anim;
    public Image[] hearts;
    public int maxHealth;
    int currentHealth;
    public GameObject sword;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        GetHealth();
    }

    private void GetHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Attack();
        Movement();
    }
    private void Attack()
    {
        GameObject newSword = Instantiate(sword, transform.position, sword.transform.rotation);
        int swordDir = anim.GetInteger("dir");
        switch (swordDir)
        {
            case 1:
                newSword.transform.Rotate(0, 0, 180);
                break;
            case 2:
                newSword.transform.Rotate(0, 0, 0);
                break;
            case 3:
                newSword.transform.Rotate(0, 0, -90);
                break;
            case 4:
                newSword.transform.Rotate(0, 0, 90);
                break;
            default:
                break;
        }
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