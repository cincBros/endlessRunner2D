using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCntroller : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    int jumps;

    public bool grounded;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (Input.GetKeyDown("up"))
        {
            if (grounded || jumps < 1)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumps++;
            }
        }
        if (Input.GetKeyDown("down"))
        {
            if (!grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -jumpForce);
            }
        }
        if (Input.GetKey("left"))
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);

        }
        if (Input.GetKey("right"))
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);

        }

        if (grounded) jumps = 0;

        if (myRigidbody.transform.position.x < screenBounds.x )
        {
            myRigidbody.transform.Translate(new Vector2(0.1f, 0));
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "prefab")
        {
            score.viu = false;
            Destroy(gameObject);
        }
    }
}
