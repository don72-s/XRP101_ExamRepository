# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안

1. 생성전 참조

객체를 생성하기 전에 해당 객체에서 getcomponent를 하여 null exception이 발생했다.

=> setcubeposition을 createcube호출 뒤로 옮겨 해결.

2. 값형식과 private

이동을 원하는 위치를 지정할 때 vector3의 get only형식으로 되어있는데 문제는 다음과 같다.

- 벡터는 값 형식이라 값복사가 일어나 받아와서 수정해도 원본이 바뀌지 않는다.
- 원본의 set을 시도하려고 하면 private라 지정이 불가능하다.

=> 세팅하는 함수를 만들어주거나 set이 가능하도록 바꾸어준 뒤, 이동 목적지 벡터를 변경해준다.