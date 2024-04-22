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
    bool jDown;
    bool isJump;

    Vector3 moveVec;

    Animator anim;

    Rigidbody rigid;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();//Player의 자식 오브젝트에 애니메이터 넣었으니까
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");//shitf는 계속 누르고 있을 때만 작동 되도록 GetButton()사용
        jDown = Input.GetButtonDown("Jump");//점프는 누른 그 순간에 하는 것
    }
    
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (wDown)
        {
            transform.position += moveVec * Speed * 0.3f * Time.deltaTime;
        }
        else
            transform.position += moveVec * Speed * Time.deltaTime;

        //애니메이션 설정
        anim.SetBool("isRun",moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && !isJump) //Jump가 false일 때 만 사용가능하다.s
        {
            rigid.AddForce(Vector3.up * 18, ForceMode.Impulse);
            anim.SetBool("isJump",true);
            anim.SetTrigger("doJump");//trigger는 설정 할 필요 없다.
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;

        }
    }
}
