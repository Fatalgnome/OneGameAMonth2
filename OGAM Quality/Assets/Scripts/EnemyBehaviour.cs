using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int health;

    public float Speed;
    public int CircleRadius;

    private bool closeToPlayer = false;
    private Vector2 direction;

    private int random;

    private Collider2D hitColliders;
	// Use this for initialization
	void Start ()
	{
	    random = Random.Range(0, 2);

        if (random == 1)
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
        if (closeToPlayer == false)
        {
           transform.Translate(direction * Speed * Time.deltaTime);
        }


        hitColliders = Physics2D.OverlapCircle(transform.position, CircleRadius);

        if (hitColliders.gameObject.tag == "Player")
        {
            closeToPlayer = true;
        }

        if(hitColliders.gameObject.tag != "Player")
        {
            closeToPlayer = false;
        }

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
