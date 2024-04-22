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
        if (jDown && !isJump) //Jump�� false�� �� �� ��밡���ϴ�.s
        {
            rigid.AddForce(Vector3.up * 18, ForceMode.Impulse);
            anim.SetBool("isJump",true);
            anim.SetTrigger("doJump");//trigger�� ���� �� �ʿ� ����.
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
