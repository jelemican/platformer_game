using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    private float speed = 10.0F;
    private Vector3 direction;
    private bool flip;
    public bool Flip
    {
        set { flip = value; }
    }
    public Vector3 Direction { set { direction = value; } }
    public SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.flipX = flip;
    }
    private void Start()
    {
        Destroy(gameObject, 1.5F);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
