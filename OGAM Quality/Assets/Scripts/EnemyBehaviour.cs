using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int health;

    public float Speed;

    private Vector2 direction;

    private int random;
	// Use this for initialization
	void Start ()
	{
	    random = Random.Range(0, 1);
	    if (random == 0)
	    {
	        direction = Vector2.left;
	    }
	    else
	    {
	        direction = Vector2.right;
	    }
	}
	
	// Update is called once per frame
	void Update ()
    {  
		transform.Translate(direction * Speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if(direction.x == -1)
            {
                direction.x = 1;
            }
            else if (direction.x == 1)
            {
                direction.x = -1;
            }

        }
    }
}
