using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed = 8f;

    Rigidbody m_playerRigid;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_playerRigid = transform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            StartCoroutine(coMove());
    }

    IEnumerator coMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * m_speed;
        float zSpeed = zInput * m_speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        m_playerRigid.velocity = newVelocity;

        yield return null;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
