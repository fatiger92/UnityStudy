using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid; // �̵��� ����� ������ �ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    void Update()
    {
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
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
