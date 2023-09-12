using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    public GameObject Effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(Effect,transform.position, Quaternion.identity);
        Destroy(explosion, 2.0f);
        Destroy(this.gameObject);

    }
}
