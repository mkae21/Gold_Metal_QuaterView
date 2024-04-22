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
    Vector3 dodgeVec;//ȸ�� ���� ������ȯ�� ���� �ʵ��� ȸ�ǹ��� Vector3 �߰�

    Animator anim;

    Rigidbody rigid;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();//Player�� �ڽ� ������Ʈ�� �ִϸ����� �־����ϱ�
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
        wDown = Input.GetButton("Walk");//shitf�� ��� ������ ���� ���� �۵� �ǵ��� GetButton()���
        jDown = Input.GetButtonDown("Jump");//������ ���� �� ������ �ϴ� ��
    }
    
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isDodge)//ȸ�� �߿��� ������ ���� -> ȸ�ǹ��� ���ͷ� �ٲ�� ����.
        {
            moveVec = dodgeVec;
        }

        if (wDown)
        {
            transform.position += moveVec * Speed * 0.3f * Time.deltaTime;
        }
        else
            transform.position += moveVec * Speed * Time.deltaTime;

        //�ִϸ��̼� ����
        anim.SetBool("isRun",moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge) //Jump,Dodge�� false�� �� �� ��밡���ϴ�, �� �� ���� ���� �Ұ���
                                                                     
        {
            rigid.AddForce(Vector3.up * 18, ForceMode.Impulse);
            anim.SetBool("isJump",true);
            anim.SetTrigger("doJump");//trigger�� true,false ���� �� �ʿ� ����.
            isJump = true;
        }
    }

    void Dodge()
    { 
        if(jDown && moveVec != Vector3.zero && !isJump && !isDodge)//Dodge�� Jump�� ���ÿ� ������� �ʵ��� ����
        {
            dodgeVec = moveVec;
            Speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.5f);//0.5�� �ڿ� DodgeOut()�Լ� ����
        }
    }

    void DodgeOut()//isDodge�� false�� �ٲ�� ��,Land animation �����ϱ� ���ؼ�
    {
        Speed *= 0.5f;
        isDodge = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);//�ִϸ��̼�
            isJump = false;

        }
    }
}
