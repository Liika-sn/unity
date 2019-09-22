using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider2D PlayerColl;
    public int health; // здоровье 
    private Rigidbody2D RB;
    private Vector3 direction;
    public float speed;
    public Transform gunPos;

    public GameObject bulletPref;

    private float horizontal;

    private bool right;

    void Start()
    {
        speed = 2;
        health = 100;
        RB = GetComponent<Rigidbody2D>();
    }

    private void Shoot()
    {
        GameObject temp = Instantiate(bulletPref, gunPos.position, Quaternion.identity);
        temp.name = "bullet";
        temp.GetComponent<Bullet>().direction = (!right) ? 1 : -1;
    }

    private void Flip()
    {
        right = !right;
        Vector2 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;

    }
    private void Move()
    {
        if (horizontal > 0 && right)
        {
            Flip();
        }
        else if (horizontal < 0 && !right)
        {
            Flip();
        }
        direction = Vector3.right * horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
}

