using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    [HideInInspector]
    public SpriteRenderer enemySR;

    Rigidbody2D myBody;

    private void Awake()
    {
        enemySR = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        //speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
