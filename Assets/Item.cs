using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //������ +  ������ ������ Ÿ��
    //��, �̴� Type�̶�� ������ Ÿ���� ������� ���̴�.
    // Ammo,Coin,Grenade,Heart,Weapon �� �ټ������� ��� ���� �ִ�


    public enum Type {Ammo,Coin,Grenade,Heart,Weapon};//������ ������ Ÿ���� �������
    public Type type;//������ ������ Ÿ���� ������ ����
    public int value;//�������� ��ġ�� ��Ÿ���� ����

    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }

}
