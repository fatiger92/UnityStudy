using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigid; // �̵��� ����� ������ �ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    private void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region �� ��ȿ������ Ű����
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //���� ����Ű �Է��� ������ ��� z ���� �� �ֱ�    
            playerRigid.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //�Ʒ��� ����Ű �Է��� ������ ��� -z ���� �� �ֱ�    
            playerRigid.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //������ ����Ű �Է��� ������ ��� x ���� �� �ֱ�    
            playerRigid.AddForce(speed , 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //���� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�    
            playerRigid.AddForce(-speed, 0f, 0f);
        }
        */
        #endregion

        #region ȿ������ Ű����

        // ������� �������� �Է� ���� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigid.velocity = newVelocity;

        #endregion
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
