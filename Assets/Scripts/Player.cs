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
    public float thrustPower;
    public bool canMove;
    public bool canAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        GetHealth();
        canMove = true;
        canAttack = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && canAttack) 
            Attack();
        Movement();
    }
    private void Attack()
    {
        canMove = false;
        canAttack = false;
        GameObject newSword = Instantiate(sword, transform.position, sword.transform.rotation);
        anim.speed = 1;
        anim.SetBool("atk-anim", true);
        #region //SwordRotation
        int swordDir = anim.GetInteger("dir");
        switch (swordDir)
        {
            case 1:
                newSword.transform.Rotate(0, 0, 180);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrustPower);
                break;
            case 2:
                newSword.transform.Rotate(0, 0, 0);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrustPower);
                break;
            case 3:
                newSword.transform.Rotate(0, 0, -90);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrustPower);
                break;
            case 4:
                newSword.transform.Rotate(0, 0, 90);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower);
                break;
            default:
                break;
        }
        #endregion
    }

    private void Movement()
    {
        if (!canMove)
            return;
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        RunPlayerAnimation();
    }

    private void RunPlayerAnimation()
    {
        anim.speed = 1;
        #region  //AnimationDirection
        if (canMove)
        {
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
        #endregion

    }

}