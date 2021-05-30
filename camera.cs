using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    public float speed = 2.0F;
    public Transform target;
    public void Awake()
    {
        if (!target) target = FindObjectOfType<Chel>().transform;
    }
    public void Update()
    {
        if (!transform) Destroy(gameObject);
        if (target) 
        {
            Vector3 position = target.position;
            position.z = -5.0F;
            position.y = position.y + 2.0F;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }

}
