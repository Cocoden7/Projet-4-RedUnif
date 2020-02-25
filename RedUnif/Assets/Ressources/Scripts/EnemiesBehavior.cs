using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{

	private bool avance = true;
	private int a = 0;
	public Rigidbody2D rb;
	Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
		movement.y = 0.0f;
		movement.x = 1.0f;
    	StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {}

    IEnumerator Movement()
    {
    	while(true)
    	{
    		yield return new WaitForSeconds(1.0f);
    		if(a <= 0)
    		{
    			avance = true;
    		}
    		if(a >= 3)
    		{
    			avance = false;
    		}
    		if(avance)
    		{
    			rb.MovePosition(rb.position += movement);
    			a++;
    		}
    		else
    		{
    			a = a - 1;
    			rb.MovePosition(rb.position -= movement);
    		}
    	}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	print("credit gagne!");
    	col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
    }

}
