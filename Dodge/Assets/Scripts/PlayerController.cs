using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid; // 이동에 사용할 리지드 바디 컴포넌트
    public float speed = 8f; // 이동 속력

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //위쪽 방향키 입력이 감지된 경우 z 방향 힘 주기    
            playerRigid.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //아래쪽 방향키 입력이 감지된 경우 -z 방향 힘 주기    
            playerRigid.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //오른쪽 방향키 입력이 감지된 경우 x 방향 힘 주기    
            playerRigid.AddForce(speed , 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 방향키 입력이 감지된 경우 -x 방향 힘 주기    
            playerRigid.AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
