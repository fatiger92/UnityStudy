using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigid; // 이동에 사용할 리지드 바디 컴포넌트
    public float speed = 8f; // 이동 속력

    private void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region 좀 비효율적인 키조작
        /*
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
        */
        #endregion

        #region 효율적인 키조작

        // 수평축과 수직축의 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //리지드바디의 속도에 newVelocity 할당
        playerRigid.velocity = newVelocity;

        #endregion
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
