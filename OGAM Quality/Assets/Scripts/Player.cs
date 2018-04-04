using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float curSpeed;
    private Vector2 movDir;
    private Rigidbody2D rigidbody;

    public LayerMask groundLayer;
    public float Speed = 3.0f;
    public float jumpSpeed;
    public int Health;
    

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            movDir += Vector2.left;
            transform.Translate(movDir * Speed * Time.deltaTime, Camera.main.transform);
        }
        else
        {
            movDir = transform.forward;
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            movDir += Vector2.right;
            transform.Translate(movDir * Speed * Time.deltaTime, Camera.main.transform);
        }
        else
        {
            movDir = transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, 1, groundLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, 1, groundLayer);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            return true;
        }

        return false;
    }

    public void LoseHealth(int dmg)
    {
        Health -= dmg;
    }

}
