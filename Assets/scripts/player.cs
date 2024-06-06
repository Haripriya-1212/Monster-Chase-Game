using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    float jumpForce = 13f;
    float movementX;
    int count = 0;

    public Image[] health;

   
    Rigidbody2D mybody;
    SpriteRenderer sr; 
    Animator anim;

    bool isGrounded = true;
    string walkAnim = "walk";
    string groundTag = "ground";
    string enemyTag = "enemy";


    public GameObject ui;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //bocC = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = new Vector3(-7.58f, -2.86f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        animatePlayer();
        playerJump();
    }

    //private void FixedUpdate()
    //{
    //    playerJump();
    //}

    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
        //transform.position.x += movementX * moveSpeed * Time.deltaTime;

        //Debug.Log(Time.deltaTime);
    }

    void animatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(walkAnim, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(walkAnim, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(walkAnim, false);
        }
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(enemyTag))
        {
            healthDestroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            healthDestroy(collision.gameObject);
        }
    }




    void healthDestroy(GameObject enemy)
    {
        count++;
        if (count < 4)
        {
            //ghostBC.isTrigger = true;
            //enemyBody.bodyType = RigidbodyType2D.Kinematic;
            health[count - 1].enabled = false;
            Destroy(enemy);          
            
        }
        else
        {
            health[3].enabled = false;
            Destroy(gameObject);
            ui.gameObject.GetComponent<uiController>().gameOverDisplay();
        }
    }




}
