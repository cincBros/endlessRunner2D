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
    public GameObject helmet;

    
    private int jumps;
    public bool grounded, hasJumped;
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
        hasJumped = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround) && !hasJumped;

        // MOVE
        if (Input.GetKeyDown("up"))
        {
            hasJumped = true;
            if (!teMolles && (grounded || jumps < 2))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                grounded = false;
            }
            else if (teMolles && grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce * 1.5f);
                grounded = false;
            }
            jumps++;
            gameObject.GetComponent<Animator>().SetBool("jump", true);
        }
        else hasJumped = false;
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
        if (grounded)
        {
            jumps = 0;
            gameObject.GetComponent<Animator>().SetBool("jump", false);
        }

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
                activarCasc(false);

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
            gameObject.GetComponent<Animator>().SetBool("helmet", true);
        }
        else
        {
            teCasc = false;
            gameObject.GetComponent<Animator>().SetBool("helmet", false);
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
