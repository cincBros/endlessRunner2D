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

        // MOVE
        if (Input.GetKeyDown("up"))
        {
            if (!teMolles && (grounded || jumps < 1))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
            else if (teMolles && grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce * 1.5f);
            }
            jumps++;
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

        // GROUND
        if (grounded) jumps = 0;

        // COLISION
        if (myRigidbody.transform.position.x < screenBounds.x )
        {
            myRigidbody.transform.Translate(new Vector2(0.1f, 0));
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

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

    public void activarCasc(bool activar)
    {
        if (activar)
        {
            teCasc = true;
        }
        else
        {
            teCasc = false;
        }
    }

    public void activarMolles(bool activar)
    {
        if (activar)
        {
            teMolles = true;
        }
        else
        {
            teMolles = false;
        }
    }

    public void activarPildora(bool activar)
    {
        if (activar)
        {
            tePildora = true;
        }
        else
        {
            tePildora = false;
        }
    }
}
