using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    public int Speed;
    bool wDown;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();//Player의 자식 오브젝트에 애니메이터 넣었으니까
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");//shitf는 누르고 있을 때만 작동 되도록 GetButton()사용

        moveVec = new Vector3(hAxis,0,vAxis).normalized;

        if (wDown)//shift 누를 때 
        {
            transform.position += moveVec += moveVec * Speed * 0.3f * Time.deltaTime;
        }
        else
            transform.position += moveVec * Speed * Time.deltaTime;


        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + moveVec);//(위치 + 입력된 방향 벡터) 방향으로 회전하게 한다.

    }
}
