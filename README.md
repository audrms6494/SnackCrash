<img src="https://github.com/audrms6494/SnackCrash/assets/141597722/03828b9e-5d27-4446-8ba5-203f7cf3f8f7" width="200" height="200"/>

# A11 십시일반 팀 프로젝트 - 과자 부수기 (Snack Crash)
<br/>
## 플레이 영상
## 플레이 영상 촬영하시면 여기에 링크 작성합니다.

## 팀원 & 프로젝트 소개
---
|이름|담당|깃허브 주소|
|------|---|------|
|송명근|팀장|[링크](https://github.com/audrms6494)|
|김진성|팀원|[링크](https://github.com/GYALLERHORN)|
|이정환|팀원|[링크](https://github.com/jhwan328)|
|함영주|팀원|[링크](https://github.com/HamYoungjoo)|

<br/>

- 프로젝트 소개 : 요즘 어린 아이들이 밥을 안 먹고 과자만 먹어 건강을 해치는 일이 늘어나고 있다… 아이들의 건강을 해치는 일은 절대로 용서할 수 없지… 나 ‘밥’이 과자를 모두 부수고 아이들의 건강을 책임진다!


## 프로젝트 기획 - 와이어프레임
---
<img width="1254" alt="팀십시일반와이어프레임" src="https://github.com/audrms6494/SnackCrash/assets/141597722/3a7b28a4-d64b-402e-8136-ff28a899fdba">
draw.io를 이용한 와이어프레임 기획서 작성

<br/>

### 와이어프레임 상세 - 각 Scene의 구성

- Start Scene : 게임의 시작화면으로 난이도 선택화면, 크레딧 화면으로 이동이 가능하고, 배경음악의 on/off 조절, 플레이어 데이터 초기화 기능 버튼이 있다.
- Select Scene : 3개의 레벨 스테이지로 구성하며 선택한 난이도에 따라 Main Scene에 패들 길이, 벽돌 수, 기믹 등이 달라진다. 난이도 선택 버튼 위에 지금까지의 최고 기록이 표시된다.
- Main Scene : 게임을 진행하는 화면으로 패들에 공을 튕겨 벽돌에 충돌 시켜 벽돌을 사라지게 하면 점수가 올라간다.
- Result Scene : 게임 오버가 되면 나타나는 화면으로 사용자의 이름을 입력 받아 게임 기록을 입력할 수 있고, 이전 최고 기록들을 확인 할 수 있다.
- Credit Scene : 개발자의 정보 표시 화면.

### 게임 플레이 설명
- 고전 게임 "벽돌깨기"를 표방한 게임이다. 하단에 위치한 접시(패들)을 좌우로 움직이면 전 화면을 자유롭게 움직이는 공과 충돌하여, 공을 반사시킨다.
- 이 과정을 통해 상단의 모든 쿠키(벽돌)을 공과 충돌시켜 모두 없애면 게임이 클리어된다. 모든 쿠키를 없애기 전에 화면 최하단의 경계선과 공이 닿으면 게임 오버다.
- 없앤 쿠키의 수에 비례해 획득 점수가 증가하며, 클리어/게임오버 시 획득한 점수를 이전 점수와 비교하여 순위를 매긴다.
- 스테이지는 난이도에 따라 총 3개로 구성되며, 현재 스테이지를 클리어하지 않으면 다음 난이도의 스테이지를 진행할 수 없다.

<br/>

### 역할 분담
- 송명근
    - Result Scene 담당
    - 게임 기록 저장 기능
    - 플레이어 이름 입력 받기 기능
- 김진성
    - Select Scene 담당, 난이도에 따른 스테이지 선택 로직 작성
- 이정환
    - Main Scene 담당 - 벽돌, 공, 패들 생성 기능 (생성 매니저) 등 인 게임 로직 구현
- 함영주
    - Start Scene, Credit Scene 담당
    - Scene간 이동 기능
    - UI 및 사운드 옵션 기능



























