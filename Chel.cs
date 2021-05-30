using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Chel : MonoBehaviour
{
    public int health = 100;
    public int guys = 20;
    private float speed = 4.5F;
    private float jumpforce = 15.0F;
    new public Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer sprite;
    public bool smtharound = false;
    public health_num score;
    public bool direct = false;
    private Bullet bullet;
    public int Health
    {
        get { return health; }
    }
    public int Guys
    {
        get { return guys; }
        set { guys = value; }
    }
    public void Start()
    {
        score = FindObjectOfType<health_num>();
    }
    public virtual void ReceiveDamage(int damage)
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
        if (health - damage >0)
        {
            health = health - damage;
            score.UpdateHealth(health, guys);
        }
        else
        {
            health = health - damage;
            score.UpdateHealth(health, guys);
            Die();
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(1);
    }
    private void FixedUpdate()
    {
        checkaround();
    }
    private void Awake()
    {
        rigidbody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }
    private void Update()
    {
        if (smtharound) number = anims.eddy_idle;
        if (Input.GetButton("Horizontal"))
        {
            run();
        }
        if (smtharound && Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        direct = direction.x < 0.00F;
        sprite.flipX = direct;
        if (smtharound) number = anims.eddy_run;
    }
    private void jump()
    {
        rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        number = anims.eddy_jump;
    }
    private void shoot()
    {
        Vector3 position = transform.position;
        position.y = position.y + 3.7F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        newBullet.Flip = sprite.flipX;
        guys--;
    }
    private void checkaround()
    {
        Collider2D[] x = Physics2D.OverlapCircleAll(transform.position, 1.0F);
        smtharound = x.Length > 2;
        if (!smtharound) number = anims.eddy_jump;
    }
    private anims number
    {
        get { return (anims)animator.GetInteger("number"); }
        set { animator.SetInteger("number", (int)value); }
    }
}
public enum anims
{
    eddy_idle, eddy_run, eddy_jump
}