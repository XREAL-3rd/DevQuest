using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private static float HEIGHT = 2f;
    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpAmount = 4f;
    [SerializeField] private float damage = 10f;    

    [Header("Debug")]
    public MovementStateManager movementStateManager;
    private float stateTime;

    public Transform shootOrigin;
    public GameObject projectilePrefab;

    public PlayerRenderer animator;

    public bool landed = true, moving = false, shooting = false;
    //1회차 과제에서 공격 애니메이션을 추가하고 싶다면, 공격 중에는 animator.rangeAttack를 참으로 설정하거나, 공격 시작시 animator.MeleeAttack()을 호출하세요.
    //전자는 참일 동안 원거리 공격 애니메이션을, 후자는 호출 시 근거리 공격 애니메이션을 재생합니다.
    //구현 자체는 PlayerRenderer.cs를 참조하세요.
    public Quaternion rotation = Quaternion.identity;
    private Rigidbody rigid;
    private Collider col;
    private Transform camt;

    private void Start() {
        camt = FindObjectOfType<Camera>().transform;
        movementStateManager = GetComponent<MovementStateManager>();

        rotation = transform.rotation;
    }

    private void Update() {
        //3. 글로벌 & 스테이트 업데이트
        // 공격 정보 업데이트 
        UpdateAttack();
        //insert code here...
    }

    //땅에 닿았는지 여부를 확인하고 landed를 설정해주는 함수
    private void CheckLanded() {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    private void CheckShooting() {
        // animator가 끝났는지 확인하는 방법이 뭐가 있을까요?
    }

    private void UpdateAttack(){
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){

        RaycastHit hit;
        Ray aim;
        aim = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject projectile_temp = Instantiate(projectilePrefab, shootOrigin.position, rotation);
        Destroy(projectile_temp, 5f);
        // GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);
        
        // // 방향이 정확하지 않은 것 같음. 어떤 요소 가져와야 정확한 방향이 생성될지
        // Debug.Log(aim.direction);
        // projectile.GetComponent<Projectile>().SetUp(transform.forward);
        // projectile.GetComponent<Projectile>().Fire();
        
        if(Physics.Raycast(aim, out hit)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
            }
        }
    }

    //카메라 기준으로 앞과 우측 벡터를 계산해주는 함수
    private Vector3 ForwardVector() {
        Vector3 v = camt.forward;
        v.y = 0;
        v.Normalize();
        return v;
    }

    private Vector3 RightVector() {
        Vector3 v = camt.right;
        v.y = 0;
        v.Normalize();
        return v;
    }
}
