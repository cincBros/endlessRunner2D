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
    public float mollesTime, pildoraTime, tacklingTime, groundedDetectionTime;
    public GameObject helmet;

    
    private int jumps;
    public bool grounded;
    public bool teCasc, teMolles, tePildora, teRelan;
    public bool viu;
    public bool tackling;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Vector2 screenBounds;
    private float playerWidth;



    // Start is called before the first frame update
    void Start()
    {
        viu = true;
        teMolles = teCasc = tePildora = teRelan = tackling = false;
        mollesTime = pildoraTime = tacklingTime = groundedDetectionTime = 0.0f;
        jumps = 0;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        soundManager.PlaySound("xiulet");
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE
        if (Input.GetKeyDown("up"))
        {
            if (tackling)
            {
                tacklingTime = 0.0f;
            }
            else
            {
                if (!teMolles && (grounded || jumps < 2))
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                }
                else if (teMolles && grounded)
                {
                    soundManager.PlaySound("boing");
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce * 1.5f);
                }
                jumps++;
                groundedDetectionTime = 0.2f;
                grounded = false;
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
                tacklingTime = 3.0f;
                tackling = true;
                gameObject.GetComponent<Animator>().SetBool("tackle", true);
            }
        }
        if (Input.GetKey("left"))
        {
            if (!tackling)
            {
                myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
            }

        }
        if (Input.GetKey("right"))
        {
            if (!tackling)
            {
                myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
            }

        }

        // GROUND
        if (groundedDetectionTime <= 0.0f)
        {
            grounded = IsGrounded();
            if (grounded)
            {
                jumps = 0;
                gameObject.GetComponent<Animator>().SetBool("jump", false);
            }
        }
        else
        {
            groundedDetectionTime -= Time.deltaTime;
        }

        // COLISION
        DontGoOutsideRange(screenBounds.x + 2f, 10f);

        if (tacklingTime <= 0.0f)
        {
            tackling = false;
            gameObject.GetComponent<Animator>().SetBool("tackle", false);
        }
        else
        {
            tacklingTime -= Time.deltaTime;
        }
    }

    private void DontGoOutsideRange(float left, float right)
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + playerWidth, screenBounds.x * -1 - playerWidth);
        transform.position = viewPos;
    }

    private bool IsGrounded()
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

    public void activarRelan(bool activar)
    {
        if (activar)
        {
            teRelan = true;
        }
        else
        {
            teRelan = false;
        }
    }
}
