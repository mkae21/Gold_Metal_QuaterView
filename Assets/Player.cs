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
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");//shitf�� ������ ���� ���� �۵� �ǵ��� GetButton()���

        moveVec = new Vector3(hAxis,0,vAxis).normalized;

        if (wDown)//shift ���� �� 
        {
            transform.position += moveVec += moveVec * Speed * 0.3f * Time.deltaTime;
        }
        else
            transform.position += moveVec * Speed * Time.deltaTime;


        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + moveVec);//(��ġ + �Էµ� ���� ����) �������� ȸ���ϰ� �Ѵ�.

    }
}
