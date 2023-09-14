<img src="https://github.com/audrms6494/SnackCrash/assets/141597722/03828b9e-5d27-4446-8ba5-203f7cf3f8f7" width="200" height="200"/>

# A11 십시일반 팀 프로젝트 - 과자 부수기 (Snack Crash)

<br/>

## 플레이 영상
플레이 영상 촬영하시면 여기에 링크 작성합니다.========================================================================

## 팀원 & 프로젝트 소개
---
|이름|담당|깃허브 주소|
|------|---|------|
|송명근|팀장|[링크](https://github.com/audrms6494)|
|김진성|팀원|[링크](https://github.com/GYALLERHORN)|
|이정환|팀원|[링크](https://github.com/jhwan328)|
|함영주|팀원|[링크](https://github.com/HamYoungjoo)|

<br/>

- 프로젝트 소개 : 요즘 어린 아이들이 밥을 안 먹고 과자만 먹어 건강을 해치는 일이 늘어나고 있다… 아이들의 건강을 해치는 일은 절대로 용서할 수 없지… 나 ‘밥그릇’이 과자를 모두 부수고 아이들의 건강을 책임진다!


## 프로젝트 기획 - 와이어프레임
---
<img width="1254" alt="팀십시일반와이어프레임" src="https://github.com/audrms6494/SnackCrash/assets/141597722/3a7b28a4-d64b-402e-8136-ff28a899fdba">
draw.io를 이용한 와이어프레임 기획서 작성

** 와이어프레임 작성 URL => [링크](https://app.diagrams.net/#G1rHMNreOOOkFnLEOfuzSe6Tx4GynSDCbe) **

<br/>

### 와이어프레임 상세 - 각 Scene의 구성

- Start Scene : 게임의 시작화면으로 난이도 선택화면, 크레딧 화면으로 이동이 가능하고, 배경음악의 on/off 조절, 플레이어 데이터 초기화 기능 버튼이 있다.
- Select Scene : 3개의 레벨 스테이지로 구성하며 선택한 난이도에 따라 Main Scene에 패들 길이, 벽돌 수, 기믹 등이 달라진다. 난이도 선택 버튼 위에 지금까지의 최고 기록이 표시된다.
- Main Scene : 게임을 진행하는 화면으로 패들에 공을 튕겨 벽돌에 충돌 시켜 벽돌을 사라지게 하면 점수가 올라간다.
- Result Scene : 게임 오버가 되면 나타나는 화면으로 사용자의 이름을 입력 받아 게임 기록을 입력할 수 있고, 이전 최고 기록들을 확인 할 수 있다.
- Credit Scene : 개발자의 정보 표시 화면.

### 작업 환경
- 유니티 : 2022.3.2f 버전
- 프로젝트 플레이 해상도 : 760*1080 범용 스마트폰 해상도

### 게임 플레이 설명
- 고전 게임 "벽돌깨기"를 표방한 게임이다. 하단에 위치한 접시(패들)을 좌우로 움직이면 전 화면을 자유롭게 움직이는 공과 충돌하여, 공을 반사시킨다.
- 이 과정을 통해 상단의 모든 쿠키(벽돌)을 공과 충돌시켜 모두 없애면 게임이 클리어된다. 모든 쿠키를 없애기 전에 화면 최하단의 경계선과 공이 닿으면 게임 오버다.
- 없앤 쿠키의 수에 비례해 획득 점수가 증가하며, 클리어/게임오버 시 획득한 점수를 이전 점수와 비교하여 순위를 매긴다.
- 스테이지는 난이도에 따라 총 3개로 구성되며, 현재 스테이지를 클리어하지 않으면 다음 난이도의 스테이지를 진행할 수 없다.

### 역할 분담
- 송명근
    - Result Scene 담당
    - 게임 기록 저장 기능
    - 플레이어 이름 입력 받기 기능
- 김진성
    - Select Scene 담당 - 난이도에 따른 스테이지 선택 로직 작성
- 이정환
    - Main Scene 담당 - 벽돌, 공, 패들 생성 기능 (생성 매니저) 등 인 게임 로직 구현
- 함영주
    - Start Scene, Credit Scene 담당
    - Scene간 이동 기능
    - UI 및 사운드 옵션 기능
 <br/>
 
위와 같이 각 Scene마다 역할을 나눠 작업하며, 브랜치 Merge 시 작업 내용의 conflict를 최소화했다.

<br/>

## Scene 상세 설명
---
### StartScene
![스크린샷 2023-09-13 212716](https://github.com/audrms6494/SnackCrash/assets/141597722/b1740422-8f01-4a43-8de7-15319b2774f0)

1. 배경음악 on/off 기능 버튼 
2. 이 프로젝트의 타이틀, 클릭하면 CreditScene으로 전환된다.
3. 클릭 시 SelectScene으로 전환된다.
4. 클릭 시 난이도 별 스테이지 진행도가 초기화된다.
5. 클릭으로 플레이할 접시(패들)의 이미지를 변경할 수 있다.

### SelectScene
![스크린샷 2023-09-13 213206](https://github.com/audrms6494/SnackCrash/assets/141597722/82bfd966-68e0-422b-9742-841e9c512885)

1. 각 스테이지의 최고 점수가 기록된다.
2. 위에서부터 EASY, NORMAL, HARD 난이도의 스테이지가 있다. 현재 스테이지를 클리어하지 않으면 다음 스테이지로의 진행이 불가능하다.
3. 클릭 시 StartScene으로 전환된다.

### MainScene
![스크린샷 2023-09-13 213613](https://github.com/audrms6494/SnackCrash/assets/141597722/e0ae92c8-9319-495a-8c06-41ea05f7bff4)

1. 획득 점수를 표시한다.
2. 과자(블록). 공으로 파괴 가능하며, 파괴된 위치에서 일정 수의 아이템이 생성되어 떨어진다. 모두 파괴하면 게임 클리어, ResultScene으로 전환된다.
3. 아이템. 접시에 접촉 시 공 갯수, 접시 크기에 영향을 준다.
4. 공. 화면 양 옆의 벽, 접시, 과자에 출동하면서 화면을 자유 이동하며, 최하단의 경계에 닿으면 게임 오버, ResultScene으로 전환된다.
5. 접시(패들). 플레이어가 A,D키로 조작하며 공을 반사시켜 최하단 경계에 닿지 않도록 한다.
6. 최하단 경계

### ResultScene
![스크린샷 2023-09-13 214029](https://github.com/audrms6494/SnackCrash/assets/141597722/01c232ff-91ba-40c0-b8b2-303d2fca0ef5)

1. 게임 클리어/오버 수 획득한 점수를 표시한다.
2. 각 스테이지의 최고 점수 1~3위를 기록한다.
3. 클릭 시 5번 UI가 팝업하며, 5번의 InputText에 입력한 텍스트와 함께 기록이 저장된다.
4. 클릭 시 StartScene으로 전환된다.

### CreditScene
![스크린샷 2023-09-13 214436](https://github.com/audrms6494/SnackCrash/assets/141597722/7d1034d2-e546-402a-a94e-ff9377da05e7)

1. 플레이어가 A,D키로 조작하며 카메라와 함께 양 옆으로 이동한다. 이동 중 여러 오브젝트와 접촉하면서 참여 팀원 텍스트가 차례로 팝업한다.
2. CreditScene 최우측 팝업 UI. 클릭 시 StartScene으로 전환된다.

<br/>

## 주요 구현 기능과 적용 기술
- PlayerPrefs : 플레이어와 스테이지 레벨, 획득 점수의 관리
- 옵션 UI : 배경음악 음소거, 게임 데이터 초기화
- MainScene-BallSpawnManager, BlockSpawnManager, PaddleSpawnManager, MainSceneManager : 오브젝트 관리 Manager의 독립성 확보
- 주요 구현 기능과 적용 기술은 여기서 작성합니다 =====================================================================================

<br/>

## 프로젝트 후기
- 송명근
    - 개인적인 차원에서 게임 내에서 PlayerPrefs를 통해 데이터를 유기적으로 주고 받는 것에 익숙해질 수 있어서 좋았다. 또한 게임 로직을 구성하는 것이 아닌 UI를 꾸미는 것에는 관심이 적은 편이였는데 이번 프로젝트를 통해 어떤 방식으로 진행해야 하는지 경험을 쌓아서 좋았다.
    - 팀장으로서는 역할을 균등하게 배분하는 부분이 어려웠다. 특히 Conflict를 최소화하기 위해 멤버마다 각 Scene을 담당하는 방식으로 진행하다 보니 인 게임 작업인 MainScene의 분량이 압도적으로 많았던 것 같다.
    - 그러나 다른 멤버들도 각자의 맡은 역할을 넘어 추가적인 구현까지 최선을 다해주어 최선의 결과물이 나올 수 있었던 것 같다.
- 김진성
    - 처음으로 주도적인 계획서 작성을 시도해 보았고, 게임의 흐름이나 오브젝트의 배치 방법 면에서 이 계획서가 큰 도움을 얻었다. 조금 더 구체적인 와이어프레임의 작성을 위해 노력할 필요를 느꼈다.
    - 주로 UI 기능과 게임 데이터를 조작하는 기능을 구현했고, 게임 내 데이터의 보안과 저장 방법에 대해 의문을 가지는 시간이 됐다.
- 이정환
    - 그동안 어려움을 겪었던 필요한 기능별로 Manager를 나누면서 게임 플레이에 따라 변화하는 데이터를 관리하는 과정에 대해 이해도가 높아졌다.
    - 3개의 Manager가 각 오브젝트의 생성, 파괴, 관리를 맡고, Item은 생성과정에서 SpawnManger_Item이 필요한 Manager의 기능을 쓸 수 있게 쥐어줌으로서 기능을 구현한다.
    - 게임의 기능을 '생성'과 '파괴'로 분류하고 각 과정에서 '리스트'를 사용한 관리를 시행함으로서 게임에 필요한 모든 기능을 구현했다.
- 함영주
    - 영주님의 후기 작성란입니다============================










