using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private DestroyEnemySO KillEnemys;
    [SerializeField] private TimerSO Stop;

    public float speed = 15;
    public float jumpForce = 15;
    public float groundcheckLength = 2;
    public int totalJumps = 1;
    int slower = 0;
    int dubbleDeath;

    public GameObject DeadBody;
    public GameObject DeadBodyR;
    public GameObject DeadBodyEnemy;
    public GameObject hitBox;
    public GameObject DeathOptions;
    public GameObject DeathScene;

    Animator m_Animator;
    public Animator bazooka; 
    public Animator animator;
    private int remainingJumps;
    private Rigidbody2D rb2D;
    bool faceRight = true;
    Transform t;

    public GameObject DeathColor;

    void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("Boom"))
        {
            dubbleDeath += 1;
            if(dubbleDeath == 2)
            {
                dubbleDeath = 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DeathOptions.SetActive(true);
            DeathScene.SetActive(true);
            KillEnemys.DestroyEnemy = true;
            Stop.StopTimer = true;
            DeathColor.SetActive(true);
            Destroy(gameObject);
            GameObject deathAnimation = Instantiate(DeadBodyEnemy, t.position, DeadBodyR.transform.rotation);           
        }
    }

    void Start()
    {
        KillEnemys.DestroyEnemy = false;
        Stop.StopTimer = false;
        m_Animator = gameObject.GetComponent<Animator>();
        t = transform;
        rb2D = GetComponent<Rigidbody2D>();
        remainingJumps = totalJumps;
    }

    private void FixedUpdate()
    {
        if (dubbleDeath == 1)
        {
            DeathOptions.SetActive(true);
            DeathColor.SetActive(true);
            DeathScene.SetActive(true);

            if (faceRight == true)
            {
                KillEnemys.DestroyEnemy = true;
                Stop.StopTimer = true;
                Destroy(gameObject);
                GameObject deathAnimation = Instantiate(DeadBody, t.position, Quaternion.identity);
            }
            if (faceRight == false)
            {
                KillEnemys.DestroyEnemy = true;
                Stop.StopTimer = true;
                Destroy(gameObject);
                GameObject deathAnimation = Instantiate(DeadBodyR, t.position, DeadBodyR.transform.rotation);
            }
        }

        float ad = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * ad * speed * Time.deltaTime);
        animator.SetFloat("speed", Mathf.Abs(ad));

        if (ad < 0 && faceRight)
        {
            faceRight = false;
            t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
        }
        else if (ad > 0 && !faceRight)
        {
            faceRight = true;
            t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
        }
}

    void flip()
    {
            faceRight = !faceRight;
            transform.Rotate(0f, 180f, 0f);
    }

    void Update()  
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, groundcheckLength);

        if(hit.collider !=null)
        {
            remainingJumps = totalJumps;
        }

        if(Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Debug.DrawRay(transform.position, -transform.up * groundcheckLength, Color.blue);

        if(Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8;
            jumpForce = 12;
            slower += 2;
        }

        if(slower == 4 && Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 15;
            jumpForce = 15;
            slower -= 4;
        }
    }

    private void Jump()
    {
        if(remainingJumps > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            remainingJumps--;
        }
    }
}
