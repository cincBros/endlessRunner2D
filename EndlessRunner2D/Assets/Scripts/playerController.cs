using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    #region Singleton

    public static playerController instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public float speed;
    public float jumpForce;
    public float mollesTime, pildoraTime;

    int jumps;

    public bool grounded;
    public bool teCasc, teMolles, tePildora;
    public bool viu;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        viu = true;
        teMolles = teCasc = tePildora = false;
        mollesTime = pildoraTime = 0;
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
                if (!teMolles) myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                else myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce*1.5f);
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

        if (mollesTime > 0.0f) mollesTime -= Time.deltaTime;
        else teMolles = false;

        if (pildoraTime > 0.0f) pildoraTime -= Time.deltaTime;
        else tePildora = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            if (teCasc)
            {
                teCasc = false;

            }
            else if (!tePildora)
            {
                viu = false;
                Destroy(gameObject);
            }  
        }
    }

    public void activarCasc()
    {
        teCasc = true;
    }

    public void activarMolles()
    {
        mollesTime = 10f;
        teMolles = true;
    }

    public void activarPildora()
    {
        pildoraTime = 5f;
        tePildora = true;
    }
}
