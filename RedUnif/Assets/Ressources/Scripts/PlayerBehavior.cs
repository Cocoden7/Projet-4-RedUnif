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
    int creditsNeeded = 60;

    // Update is called once per frame
    void Update()
    {
    	if(!dead)
    	{
            // Retourne -1 ou 1
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    	}
        else
        {
            movement.x = 0;
            movement.y = 0;
            // Lance la methode GameOver dans GameManager
            FindObjectOfType<DeadMenu>().GameOver();
        }
    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position += movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Collision avec le vide
    	if(col.gameObject.CompareTag("vide"))
    	{
    		print("collision");
            dead = true;
    	}
    }

    void AddCredit()
    {
    	nbCredit = nbCredit + 1;
    	if (nbCredit >= creditsNeeded)
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
    	//Application.LoadLevel(0);
    }
}
