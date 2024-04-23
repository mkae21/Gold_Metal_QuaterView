using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //열거형 +  열거할 데이터 타입
    //즉, 이는 Type이라는 데이터 타입을 만들어준 것이다.
    // Ammo,Coin,Grenade,Heart,Weapon 등 다섯가지의 상수 값이 있다


    public enum Type {Ammo,Coin,Grenade,Heart,Weapon};//열거형 데이터 타입을 만들어줌
    public Type type;//열거형 데이터 타입을 변수로 선언
    public int value;//아이템의 가치를 나타내는 변수

    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }

}
