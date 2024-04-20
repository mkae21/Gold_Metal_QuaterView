/*
 * Prefab : 게임 오브젝트를 에셋으로 보관한 형태
 * 
   moveVec = new Vector3(hAxis,0,vAxis).normalized;
   에서 normalized는 방향 값이 1로 보정된 벡터

   transform.position = moveVec * Speed * Time.deltaTime;
   transform의 이동은 컴퓨터의 성능 차이에 의해 달라지면 안되기 때문에 Time.deltaTime을 꼭 사용 해 주어야 한다.
   transform 이동은 물리 충돌을 무시하는 경우가 발생함 -> rigidbody의 Collision Detection을 Continuos로 변경

   현재 이 예시는 기본이 뛰는 것, shift를 누르면 걷기
 */