using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_speed = 8f;
    
    Rigidbody m_bulletRigid;

    void Start()
    {
        Init();
        Move();
        TimeLimit();
    }
    void Init()
    {
        m_bulletRigid = transform.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }

    public void Move()
    {
        m_bulletRigid.velocity = transform.forward * m_speed;
    }
    public void TimeLimit()
    {
        Destroy(gameObject, 3f);
    }
}
