using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour
{

    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Chel chel = collider.GetComponent<Chel>();
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            Die();
        }
        if(chel)
        {
            chel.ReceiveDamage(20);
        }
    }
}
