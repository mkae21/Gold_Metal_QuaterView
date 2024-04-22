using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    float hAxis;
    float vAxis;
    public float Speed;

    bool wDown;
    bool jDown;
    bool isJump;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;//회피 도중 방향전환이 되지 않도록 회피방향 Vector3 추가

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
        Dodge();
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

        if (isDodge)//회피 중에는 움직임 벡터 -> 회피방향 벡터로 바뀌도록 구현.
        {
            moveVec = dodgeVec;
        }

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
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge) //Jump,Dodge가 false일 때 만 사용가능하다, 두 개 동시 실행 불가능
                                                                     
        {
            rigid.AddForce(Vector3.up * 18, ForceMode.Impulse);
            anim.SetBool("isJump",true);
            anim.SetTrigger("doJump");//trigger는 true,false 설정 할 필요 없다.
            isJump = true;
        }
    }

    void Dodge()
    { 
        if(jDown && moveVec != Vector3.zero && !isJump && !isDodge)//Dodge와 Jump가 동시에 실행되지 않도록 설정
        {
            dodgeVec = moveVec;
            Speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.5f);//0.5초 뒤에 DodgeOut()함수 실행
        }
    }

    void DodgeOut()//isDodge를 false로 바꿔야 함,Land animation 실행하기 위해서
    {
        Speed *= 0.5f;
        isDodge = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);//애니메이션
            isJump = false;

        }
    }
}
