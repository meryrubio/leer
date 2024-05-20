using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode leftkey, rightkey, downkey, upkey;
    public float speed = 4f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0;
        spriteRenderer.sprite = GameManager.instance.character.GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() 
    {
        dir = new Vector2(0, 0); 
        if(Input.GetKey(rightkey)) 
        {
            dir = new Vector2 (1, dir.y);
        }
        else if(Input.GetKey(leftkey)) 
        {
            dir = new Vector2 (-1, dir.y);
        }
        if(Input.GetKey(upkey)) 
        {
            dir = new Vector2 (dir.x, 1);
        }
        else if(Input.GetKey(downkey)) 
        {
            dir = new Vector2 (dir.x, -1);
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    private void OnDisable()//se desabilita el player movement
    {
        rb.velocity = new Vector2(0, 0);
    }
}
