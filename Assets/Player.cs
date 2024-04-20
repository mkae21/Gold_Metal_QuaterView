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
        anim = GetComponentInChildren<Animator>();//Player�� �ڽ� ������Ʈ�� �ִϸ����� �־����ϱ�
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");//shitf�� ������ ���� ���� �۵� �ǵ��� GetButton()���
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (wDown)
        {
            transform.position += moveVec * Speed * 0.3f * Time.deltaTime;
        }
        else
            transform.position += moveVec * Speed;

        anim.SetBool("isRun",moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
}
