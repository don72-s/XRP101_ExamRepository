# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안

1. 잘못된 몬스터를 공격하는 문제
   기본적으로 사거리 범위 내에 있는 shildmonster가 idamageable 인터페이스를 구현하지 않는데도
   범위에 있는 모든 충돌체에게서 idamageable을 가져오려고 해서 nullexception이 발생해 이후 처리를 하지 못하는 상황 발생

- 공격 판정을 하는곳에 null인경우 continue하도록 코드를 삽입하여 해결

2. attack state에서 나가지 못하는 문제
   오버라이드 메소드의 exit함수 내부에 changestate를 작성한것이 문제.
   changestate는 내부에서 exit => 상태 변환 => enter 순서로 작동하는데, attack의 exit => idle로의 change => 이를 위해 attack의 exit => 에서 idle로의 changestate...
   의 무한루프가 걸려서 콜스택 오버플로우가 발생.
   enter와 exit는 statemachine에서만 호출하고 각 상태에서는 호출하면 안되는 구조로 설계됨.

- attack스크립트의 공격 루틴시의 exit호출 제거 및 changestate(idle)로 코드를 이동/대체하여 해결.