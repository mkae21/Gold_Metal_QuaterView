/*
 * Prefab : ���� ������Ʈ�� �������� ������ ����
 * 
   moveVec = new Vector3(hAxis,0,vAxis).normalized;
   ���� normalized�� ���� ���� 1�� ������ ����

   transform.position = moveVec * Speed * Time.deltaTime;
   transform�� �̵��� ��ǻ���� ���� ���̿� ���� �޶����� �ȵǱ� ������ Time.deltaTime�� �� ��� �� �־�� �Ѵ�.
   transform �̵��� ���� �浹�� �����ϴ� ��찡 �߻��� -> rigidbody�� Collision Detection�� Continuos�� ����

   ���� �� ���ô� �⺻�� �ٴ� ��, shift�� ������ �ȱ�
 */