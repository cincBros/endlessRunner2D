using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float mollesTime, pildoraTime, groundedDetectionTime;
    
    private int jumps;
    public bool grounded, jumping;
    public bool teCasc, teMolles, tePildora, teRelan;
    public bool viu;
    public bool tackling;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private Vector2 screenBounds;
    private float playerWidth;

    public GameObject helmet;
    private Color helmetColor;

    public HelmetDie helmetDie;


    // Start is called before the first frame update
    void Start()
    {
        viu = true;
        teMolles = teCasc = tePildora = teRelan = tackling = false;
        mollesTime = pildoraTime = groundedDetectionTime = 0.0f;
        jumps = 0;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        soundManager.PlaySound("xiulet");
        //soundManager.PlaySound("musica");

        helmetColor = helmet.GetComponent<SpriteRenderer>().color;
        helmetColor.a = 0;
        helmet.GetComponent<SpriteRenderer>().color = helmetColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (viu)
        {
            UpdateAlive();
        }
        else
        {
            UpdateDead();
        }
    }

    private void UpdateAlive()
    {
        CheckInput();

        // GROUND
        if (groundedDetectionTime <= 0.0f)
        {
            grounded = IsGrounded();
            if (grounded)
            {
                jumps = 0;
                gameObject.GetComponent<Animator>().SetBool("jump", false);
                helmet.GetComponent<Animator>().SetBool("jump", false);
            }
        }
        else
        {
            groundedDetectionTime -= Time.deltaTime;
        }

        // COLISION
        DontGoOutsideRange(screenBounds.x + 2f, 10f);

        if (!tackling)
        {
            gameObject.GetComponent<Animator>().SetBool("tackle", false);
            helmet.GetComponent<Animator>().SetBool("tackle", false);
        }
    }

    private void UpdateDead()
    {

    }


    private void CheckInput()
    {
        if (Input.GetButton("Jump"))
        {
            if (!jumping)
            {
                jumping = true;

                if (tackling)
                {
                    tackling = false;
                }
                else
                {
                    if (!teMolles && (grounded || jumps < 2))
                    {
                        soundManager.PlaySound("jump");
                        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    }
                    else if (teMolles && grounded)
                    {
                        soundManager.PlaySound("jump");
                        soundManager.PlaySound("boing");
                        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce * 1.5f);
                    }
                    jumps++;
                    groundedDetectionTime = 0.2f;
                    grounded = false;
                    gameObject.GetComponent<Animator>().SetBool("jump", true);
                    helmet.GetComponent<Animator>().SetBool("jump", true);
                    
                }
            }   
        }
        else jumping = false;

        if (Input.GetButton("Tackle"))
        {
            
            if (!grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -jumpForce);
            }
            else
            {
                tackling = true;
                gameObject.GetComponent<Animator>().SetBool("tackle", true);
                helmet.GetComponent<Animator>().SetBool("tackle", true);
            }
        }
        else
        {
            tackling = false;
           
        }

 


       
        if (Input.GetButton("Left"))
        {
            if (!tackling)
            {
                myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
            }
        }
        else if (!Input.GetButton("Right") && !tackling) myRigidbody.velocity = new Vector2(speed * Input.GetAxis("Run"), myRigidbody.velocity.y);

        if (Input.GetButton("Right"))
        {
            if (!tackling)
            {
                myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
            }

        }
        else if (!Input.GetButton("Left") && !tackling) myRigidbody.velocity = new Vector2(speed * Input.GetAxis("Run"), myRigidbody.velocity.y);




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

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//Debug.Log("Player: entra " + collision.transform.tag);
        if (collision.transform.tag == "enemy")
        {
            if (!tePildora)
            {
                soundManager.PlaySound("hit");
                if (teCasc)
                {
                    ActivateCasc(false);
                }
                else
                {
                    Die();
                }
            }
        }
    }
	
	public bool CanUsePU(PU pu)
	{
        if (pu.name == "casc")
        {
            return !teCasc;
        }
        else if (pu.name == "molles")
        {
            return true;
        }
        else if (pu.name == "pildora")
        {
            return true;
        }
        else if (pu.name == "relantitzador")
        {
            return true;
        }
        else
        {
            return true;
        }
    }
	
	public void ActivatePU(PU pu)
	{
        if (pu.name == "casc")
        {
            //gameObject.GetComponent<Animator>().SetBool("helmet", true);
            ActivateCasc(true);
        }
        else if (pu.name == "molles")
        {
            teMolles = true;
            Slids.instance.AddSlider(pu);
        }
        else if (pu.name == "pildora")
        {
            tePildora = true;
            Slids.instance.AddSlider(pu);
            soundManager.PlaySound("getPildora");
        }
        else if (pu.name == "relantitzador")
        {
            teRelan = true;
            spawnerH.instance.speed *= 0.5f;
            spawnerH.instance.respawnTime *= 2.0f;
            DayNightCicle.instance.sunAngleSpeed *= 0.5f;
            DayNightCicle.instance.moonAngleSpeed *= 0.5f;
            Slids.instance.AddSlider(pu);
            soundManager.PlaySound("clock");
        }
	}
	
	public void DeactivatePU(PU pu)
	{
		if (pu.name == "casc")
		{
            ActivateCasc(false);
		}
		else if (pu.name == "molles")
		{
			teMolles = false;
		}
		else if (pu.name == "pildora")
		{
			tePildora = false;
		}
		else if (pu.name == "relantitzador")
		{
			teRelan = false;
			spawnerH.instance.speed *= 2.0f;
			spawnerH.instance.respawnTime *= 0.5f;
            DayNightCicle.instance.sunAngleSpeed *= 2.0f;
            DayNightCicle.instance.moonAngleSpeed *= 2.0f;
        }
	}


    private void ActivateCasc(bool activate)
    {
        teCasc = activate;
        if (activate)
        {
            helmetColor.a = 255;
            soundManager.PlaySound("getCasc");
        }
        else
        {
            helmetColor.a = 0;
        }
        helmet.GetComponent<SpriteRenderer>().color = helmetColor;
    }



    public void Die()
    {
        viu = false;
        endSounds.PlaySound("xiuletFinal");
        Destroy(gameObject);

        //WaitForSeconds(3);
        ChangeScene();

    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
