using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float CrouchSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    int difficulty;
    public Transform groundPos;
    public Transform ceilingPos;
    private bool isGrounded;
    public int bullets = 20;
    public int bonus;
    private bool somethingAbove;
    private float checkRadius = .2f;
    public LayerMask whatIsGround;
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool doubleJump;
    private bool isJumping = false;
    private GameObject[] players;
    private bool isCrouching = false;
    private bool CrouchButtonIsUp = false;
    private float Oldspeed;


    public ProjectileBeh ProjPref;
    public Transform LaunchOffset;
    public static PlayerControls instance;



    private void Start()
    {
        if (instance == null)
            instance = this;
        else
        { Destroy(gameObject); };
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
        Oldspeed = speed;        
    }
    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        somethingAbove = Physics2D.OverlapCircle(ceilingPos.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded == true && isCrouching == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if (isGrounded == true && isCrouching == false)
        {
            doubleJump = false;
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Jump") && isJumping == true && isCrouching == false)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyDown("space")&& bullets>0)
        {
            Instantiate(ProjPref, LaunchOffset.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Pow");
            bullets--;

        }


        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;

        }
        if (isGrounded == false && doubleJump == false && Input.GetButtonDown("Jump") && isCrouching == false)
        {
            isJumping = true;
            doubleJump = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (isGrounded == true && Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            speed = CrouchSpeed;
            animator.SetBool("IsCrouching", true);
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
        }
        if(isCrouching == true)
        {
            CheckCrouching();
        }
        if (isCrouching == true && CrouchButtonIsUp==true)
        {
            if(somethingAbove == false)
            {
                isCrouching = false;
                CrouchButtonIsUp = false;
                speed = Oldspeed;
                animator.SetBool("IsCrouching", false);
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
            }
        }
        
        


        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        bonus = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().bullets;
        Debug.Log(level);

        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            Destroy(players[1]);
        }
        if (level == 2)
        {
            string name = "Start position ("+ difficulty + ")(Clone)";
            //string name = "Start position (" + difficulty + ")";
            FindStartPos(name);
        }
        if(level == 1 || level == 3)
        {
            string name = "Start position (" + difficulty + ")";
            FindStartPos(name);
        }
        if (level == 0)
        {
            string name = "Start position (0)";
            FindStartPos(name);
        }
    }

    void FindStartPos(string position)
    {
        transform.position = GameObject.Find(position).transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.tag == "Bonus")
        {
            FindObjectOfType<AudioManager>().Play("Bonus");
            bullets = bonus;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            this.transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
    void CheckCrouching()
    {
        if (Input.GetButtonUp("Crouch"))
        {
            CrouchButtonIsUp = true;
        }
    }
             
}
