# 📖Chapter 3-2 Unity 게임개발 숙련 프로젝트
### 👨‍👧‍👧16조 박재열, 김국민, 박준형A, 김준호, 이민호, 조빈희

## 📌선택한 게임


- **필수 구현 사항**
    - **게임 맵 생성 및 배치**: 유니티의 Tilemap을 사용하여 게임 맵을 생성하고, 타일을 배치합니다. 맵 경로를 지정하여 적들의 이동 경로를 설정합니다.
    - **타워 생성 및 업그레이드**: 타워 오브젝트를 만들고, 플레이어가 클릭하면 해당 위치에 타워를 설치하는 인터페이스를 구현합니다. 타워 업그레이드를 위한 UI 및 로직을 추가합니다.
    - **적의 움직임과 스폰**: 적 캐릭터 오브젝트를 만들고 경로를 따라 이동시키는 로직을 구현합니다. 일정한 시간 간격으로 적을 스폰하는 시스템을 개발합니다.
    - **타워 공격 로직**: 타워가 적을 감지하고 공격하는 로직을 작성합니다. 레이캐스트 또는 콜라이더를 사용하여 적 감지를 구현합니다.
    - **적과 타워의 체력 및 공격력**: 각 적과 타워의 속성 (체력, 공격력)을 관리하는 시스템을 만듭니다. 데미지 계산 및 체력 감소 로직을 추가합니다.
    - **자원관리**: 플레이어가 자원을 획득하고 소모할 수 있는 시스템을 개발합니다. 자원 획득 및 소모에 대한 균형을 유지합니다.
    - **게임 진행 상태 표시**: UI 요소를 사용하여 현재 게임 상태를 플레이어에게 표시합니다. 플레이어의 자원, 현재 라운드, 등을 표시할 수 있도록 합니다.
    - **게임 오버 및 승리 조건**: 게임 오버 조건과 승리 조건을 구현합니다.
- **선택 구현 사항**
    - **다양한 타워 유형**: 여려 종류의 타워를 구현하고, 각 타워의 특성과 능력을 설계합니다.
    - **타워 업그레이드 트리**: 타워 업그레이드에 트리 구조를 도입하여 플레이어가 전략적으로 선택할 수 있도록 합니다.
    - **특수 능력 및 스킬**: 타워나 플레이어에게 특수 능력과 스킬을 부여하여 게임의 전략적 요소를 향상시킵니다.
    - **다양한 적 유형**: 다양한 종류의 적을 추가하여 게임의 난이도와 다양성을 높입니다.
    - **사운드 및 그래픽 향상**: 게임의 시각적 효과와 음향 효과를 개선하여 게임의 재미를 높입니다.
    - **레벨 디자인**: 다양한 레벨과 맵을 디자인하여 게임의 재미와 도전을 증가시킵니다.
    - **게임 저장 및 불러오기**: 게임 진행 상태를 저장하고 나중에 불러올 수 있는 기능을 추가하여 플레이어의 편의를 높입니다.


### ✅구현에 성공한 사항들
게임 맵 생성 및 배치
타워 생성 및 업그레이드
적의 움직임과 스폰
타워 공격 로직
적과 타워의 체력 및 공격력
자원관리
게임 오버 및 승리 조건
다양한 타워 유형
다양한 적 유형
사운드 및 그래픽 향상


-----

### 💾사용된 프로그램
Unity Engine 2022.3.2f LTS  
Visual Studio 2022(C#)

### 💾깃허브 사용 방식
Clone 방식으로 진행하였습니다.
각자의 Branch에서 작업 후 패키지를 전송해 메인에 merge했습니다.

-----

### ✅게임의 컨셉
1. 배경은 랜덤 타워 디펜스와 유사한 맵
2. TopDownView
3. 타워는 LOL의 캐릭터
4. Enemy는 LOL의 몹
5. 라운드가 지날수록 강한 Enemy가 등장
6. 최종라운드까지 클리어하면 승리

7. ## 📌게임의 정보
8. ### ⌨🖱조작법
9. Mouse LBT: 모든 상호작용

10. -----

11. ### 🤺타워 디자인
