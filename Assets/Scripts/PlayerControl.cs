using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private static float HEIGHT = 2f;

    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.
    [Header("Settings")] public PlayerRenderer animator;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float crouchingMoveSpeed = 2f;
    [SerializeField] private float jumpAmount = 4f;
    [SerializeField] private GameObject arrow;
    [SerializeField] private SkillType skill;

    [Header("Debug")] public State state = State.none;
    public State nextState = State.none;

    public bool landed = true, moving, shoot, skillShoot;

    //1회차 과제에서 공격 애니메이션을 추가하고 싶다면, 공격 중에는 animator.rangeAttack를 참으로 설정하거나, 공격 시작시 animator.MeleeAttack()을 호출하세요.
    //전자는 참일 동안 원거리 공격 애니메이션을, 후자는 호출 시 근거리 공격 애니메이션을 재생합니다.
    //구현 자체는 PlayerRenderer.cs를 참조하세요.
    public Quaternion rotation = Quaternion.identity;

    //마우스 조준 월드 좌표
    public Vector3 Aim { get; private set; }

    //아이템 효과 모아놓은 클래스
    public readonly ItemEffects itemEffects;

    private Rigidbody rigid;
    private Collider colli;
    private Transform camTransform;
    private float speed;

    public enum State
    {
        none,
        idle,
        crouching,
        jump,
        attack,
        skill,
    }

    PlayerControl()
    {
        itemEffects = new ItemEffects(this);
    }

    private void Start()
    {
        camTransform = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();
        colli = GetComponent<Collider>();

        state = State.none;
        nextState = State.idle;
        rotation = transform.rotation;
        speed = moveSpeed;
        UpdateAim();
    }

    private void Update()
    {
        //0. 글로벌 상황 판단
        CheckLanded();
        if (Game.Instance.Over) return;

        //1. 스테이트 전환 판단
        if (nextState == State.none)
        {
            switch (state)
            {
                case State.idle:
                    if (landed)
                    {
                        //좌클릭 공격
                        if (Input.GetMouseButton(0)) nextState = State.attack;
                        else if (Input.GetMouseButton(1)) nextState = State.skill;
                        else if (Input.GetKey(KeyCode.LeftShift)) nextState = State.crouching;
                        else if (Input.GetKey(KeyCode.Space)) nextState = State.jump;
                    }

                    break;
                case State.crouching:
                    if (Input.GetKeyUp(KeyCode.LeftShift)) nextState = State.idle;
                    break;
                case State.jump:
                    if (landed) nextState = State.idle;
                    break;
                case State.attack:
                    //발사 후 쏘기 애니메이션이 끝나면 attack state 종료
                    if (shoot && animator.IsAnyPlaying("Idle", "Walk"))
                    {
                        nextState = State.idle;
                        shoot = false;
                    }

                    break;
                case State.skill:
                    if (skillShoot && animator.IsAnyPlaying("Idle", "Walk"))
                    {
                        nextState = State.idle;
                        skillShoot = false;
                    }

                    break;
            }
        }

        //2. 스테이트 전환
        if (nextState != State.none)
        {
            state = nextState;
            nextState = State.none;
            switch (state)
            {
                case State.idle:
                    animator.crouching = false;
                    speed = moveSpeed;
                    break;
                case State.crouching:
                    animator.crouching = true;
                    speed = crouchingMoveSpeed;
                    break;
                case State.jump:
                    Vector3 vel = rigid.velocity;
                    //아이템 효과로 점프력 상승
                    vel.y = jumpAmount * itemEffects.JumpMul;
                    rigid.velocity = vel;
                    animator.Jump();
                    break;
                case State.attack:
                    //공격 애니메이션 시작
                    animator.RangeAttack();
                    //플레이어 기준 공격할 방향벡터, y좌표 소거로 기울어짐 방지
                    var diff = Aim - transform.position;
                    diff.y = 0;
                    rotation = Quaternion.LookRotation(diff);
                    //공격 애니메이션이 90도 틀어져 있는거 보정
                    var euler = rotation.eulerAngles;
                    euler.y += 90;
                    rotation.eulerAngles = euler;
                    //공격중엔 정지
                    rigid.velocity = Vector3.zero;
                    moving = false;
                    break;
                case State.skill:
                    //스킬 애니메이션 시작
                    animator.SkillAttack();
                    //플레이어 기준 공격할 방향벡터, y좌표 소거로 기울어짐 방지
                    var diff1 = Aim - transform.position;
                    diff1.y = 0;
                    rotation = Quaternion.LookRotation(diff1);
                    //공격중엔 정지
                    rigid.velocity = Vector3.zero;
                    moving = false;
                    break;
            }
        }

        //3. 글로벌 & 스테이트 업데이트
        switch (state)
        {
            case State.attack:
                //아직 발사 안했고, 마지막 공격애니메이션 재생 시, 발사
                if (!shoot && animator.IsPlaying("ArcherRecoil"))
                {
                    shoot = true;
                    //공격할 방향 벡터
                    var dir = Aim - transform.position;
                    var projectile = Instantiate(arrow, transform.position,
                        Quaternion.LookRotation(dir));
                    projectile.GetComponent<Rigidbody>().velocity = dir * 10;
                    //아이템 추가데미지 효과 반영
                    projectile.GetComponent<Projectile>().damage += itemEffects.AddDamage;
                }

                break;
            case State.skill:
                if (!skillShoot && animator.IsInTransition("SkillAttack"))
                {
                    skillShoot = true;
                    StartCoroutine(skill.SkillCoroutine(Aim));
                    Instantiate<GameObject>(skill.AttackVFX, Aim, Quaternion.identity);
                }

                break;
            default:
                //공격중엔 정지
                UpdateInput();
                break;
        }
    }

    //땅에 닿았는지 여부를 확인하고 landed를 설정해주는 함수
    private void CheckLanded()
    {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(
            new Vector3(colli.bounds.center.x, colli.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f),
                colli.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    //WASD 인풋을 처리하는 함수
    private void UpdateInput()
    {
        //마우스 조준 월드좌표 최신화
        UpdateAim();

        var move = Vector3.zero;
        moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            move += ForwardVector() * 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move += ForwardVector() * -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move += RightVector() * 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move += RightVector() * -1;
        }

        if (move.x != 0 || move.z != 0)
        {
            rotation = Quaternion.LookRotation(move);
            moving = true;
        }

        var vel = speed * itemEffects.Agility * move.normalized;
        vel.y = rigid.velocity.y;
        rigid.velocity = vel;
    }

    private void UpdateAim()
    {
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new(0.5f, 0.5f)), out RaycastHit hit,
                Mathf.Infinity, LayerMask.GetMask("Ground")))
            Aim = hit.point;
        else Aim = camTransform.position + camTransform.forward * 32;
    }

    //카메라 기준으로 앞과 우측 벡터를 계산해주는 함수
    private Vector3 ForwardVector()
    {
        var v = camTransform.forward;
        v.y = 0;
        v.Normalize();
        return v;
    }

    private Vector3 RightVector()
    {
        var v = camTransform.right;
        v.y = 0;
        v.Normalize();
        return v;
    }

    //Crosshair 월드 좌표 위치 여부 
    public bool IsAiming() => state == State.attack;
}