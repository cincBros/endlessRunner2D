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
    public bool grounded;
    public bool teCasc, teMolles, tePildora;
    public bool viu;
    public bool tackling;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Vector2 screenBounds;



    // Start is called before the first frame update
    void Start()
    {
        viu = true;
        teMolles = teCasc = tePildora = tackling = false;
        mollesTime = pildoraTime = 0;
        jumps = 0;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        grounded = IsGrounded();
        Debug.Log("Pildora " + tePildora);

        // MOVE
        if (Input.GetKeyDown("up"))
        {
            if (tackling)
            {
                tackling = false;
                gameObject.GetComponent<Animator>().SetBool("tackle", false);
            }
            else
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
                gameObject.GetComponent<Animator>().SetBool("jump", true);
            }
            
            
        }

        if (Input.GetKeyDown("down"))
        {
            if (!grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -jumpForce);
            }
            else
            {
                tackling = true;
                gameObject.GetComponent<Animator>().SetBool("tackle", true);
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

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 4f;
        Debug.DrawRay(position, direction, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, whatIsGround);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            if (teCasc && !tePildora)
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
