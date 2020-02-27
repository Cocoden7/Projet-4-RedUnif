using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	private bool dead = false;
	private int nbCredit = 0;

    // Update is called once per frame
    void Update()
    {
    	if(dead)
    	{
    		print("You die bro");
    		Dead();
    		dead = false;
    	}
    	// Retourne -1 ou 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position += movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    	if(col.gameObject.CompareTag("vide"))
    	{
    		print("collision");
    		dead = true;
    	}

    	if(col.gameObject.CompareTag("glue"))
    	{
    		print("oiesghdç_iàgresjd");
    	}
    }

    void AddCredit()
    {
    	nbCredit = nbCredit + 1;
    	if (nbCredit >= 60)
    	{
    		print("next level");
    	}
    }

    void OnGUI()
    {
    	GUI.Label(new Rect (10, 10, 100, 20), " Credit : " + nbCredit);
    }

    void Dead()
    {
    	dead = true;
    	Application.LoadLevel(0);
    }
}
