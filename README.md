![image](https://github.com/user-attachments/assets/bbd5c00b-9db2-4c8a-b355-ed9b2c6433e7)


구현 내용

플레이어 
캐릭터 컨트롤러 사용
플레이어에 캐릭터 컨트롤러 컴포넌트를 추가하고 설정 값을 조정하여 맵과 자연스럽게 충돌 및 중력작용이 적용되게 하였습니다. 캐릭터 컨트롤러를 사용하여 언덕, 벽 , 낭떠러지 등 자연스러운 충돌처리를 할 수 있었습니다. 캐릭터 컨트롤러를 사용하기 위해서 Player 객체에 캐릭터 컨트롤러 컴포넌트를 추가하고, 스크립트 상에서 캐릭터 컨트롤러의 Move를 사용하여 이동시키고, 중력 작용을 위해서  player_gravity함수를 생성하여 중력 문제를 해결 할 수 있었습니다. 

![image](https://github.com/user-attachments/assets/9fd383f9-3be5-42e8-9392-9b14a30cc7f2)

![image](https://github.com/user-attachments/assets/d67723b4-9c54-45ec-8879-e59216335dc9)

총알 발사 시 총알이 연발로 나가며 이어져 나가고 메모리상 부하를 일으켜 이를 방지 하기 위해서 코루틴을 사용하여 일정한 총알 발사 간격을 두었습니다. 

![image](https://github.com/user-attachments/assets/38a50f9d-d7ef-482f-936a-f0f75eadf3bd)

캐릭터의 애니메이션을 보다 자연스럽게 하기 위해서 BlendTree를 활용하여 앞뒤양옆의 움직임이 자연스럽게 바뀌었습니다. BlendTree를 활용하기 위해서, 플레이어의 애니메이터를 생성 한 뒤 기본 Idle상태에서 Blend Tree와 트랜지선을 연결 하였습니다. 그 블랜드 트리 안에는 앞 뒤 양 옆 그리고 Idle 상태의 애니메이션을 추가하였고, 2D Simple Directional의 블랜드 타입을 활용하였습니다. 

![image](https://github.com/user-attachments/assets/ba8fbf9a-49c7-4a66-9f6e-b5fa285b907e)

![image](https://github.com/user-attachments/assets/acb3bc84-5cce-4201-8dec-9c92d1f71f28)

값을 적용시키기 위해서 float 파라미터 moveX moveZ를 만들어 두었고 Idle 상태는 Bool 파라미터를 통해 만들었습니다. 

![image](https://github.com/user-attachments/assets/f3a6ce8c-34ce-4cb5-a2e8-3ef0acab7fb6)

코드 상에서 블랜드 트리의 애니메이션을 적용시키기 위해서 애니메이터를 받아오고 SetFloat함수를 통해서 moveX 값과 moveZ 값을 플레이어의 Horizontal, Veritcal 값을 전달하여 자연스러운 움직임을 만들어 냈습니다. 

몬스터는 블랜드 트리를 활용하지 않아도 쉽게 구현할 수 있겠다고 판단 하였습니다. 그리하여 애니메이터를 생성 한 이후 Idle과 Walk 스테이트를 만들었고 파라미터는 Bool 파라미터를 사용하여 애니메이션을 만들어 냈습니다. 
몬스터의 애니메이션이 작동할 때 몬스터 프리팹의 각도가 자꾸 0으로 바뀌면서 화면상에서 누워있는 모습을 계속 하게 되었습니다. 그래서 몬스터의 Update함수안에서 몬스터의 각도를 강제시켰습니다. 이후 애니메이션은 자연스럽게 일어서서 진행되었습니다. 

![image](https://github.com/user-attachments/assets/17edd362-f2b4-45bd-8335-1a95a6a2763d)

맵을 asset store에서 가져온 결과 맵이 복잡하여 몬스터를 각 맵에 인스턴싱 하여 생성하기 어려웠습니다. 따라서 직접 좌표에 지정하여 생성해주었고 각 몬스터들 마다 스크립트를 부여하였습니다. 그 몬스터들은 플레이어의 좌표를 받아와 거리를 계산하고 5 범위 안에 들어오면 플레이어를 바라보며 Walk 애니메이션이 실행되고 플레이어를 쫓아가게 구현하였습니다. 범위를 벗어나면 다시 몬스터들은 Idle 상태로 바뀝니다. 

![image](https://github.com/user-attachments/assets/071b3fa9-4f00-4abb-a034-6fe3d77338d2)

몬스터들의 스탯을 HP 50 으로 설정하였고 총알의 공격력은 10으로 설정하여 몬스터 안에 takeDamge 함수를 구현하여 총알과 충돌시 HP가 감소하고 0 이 되면 Destroy 시켰습니다. 

총알 
각 총알은 Raycast를 사용하여 벽, 몬스터 들을 구분하여 충돌처리를 하게 하였습니다. 
Tag를 비교하며 충돌을 구분하고 벽에 충돌시 그냥 튕겨나가는 모션과, 몬스터들과 충돌 시 몬스터의 HP 감소를 유발하게 하였습니다. 


![image](https://github.com/user-attachments/assets/52df218c-d48e-4f68-a045-c8e97b3481a3)


