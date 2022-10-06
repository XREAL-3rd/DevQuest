using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// 실행부 스크립트
public class BattlePanel : MonoBehaviour {
    /*
    // 체력관리 Subject
    [SerializeField]
    private Hp_Subject hp_Subject = null;

    //나,상대 체력 Obsever 
    //[SerializeField]
    //private MyHp_Observer myHp_Observer = null;
    //[SerializeField]
    //private EnemyHp_Observer enemyHp_Observer = null;

    // 동작을 위한 버튼
    [SerializeField]
    private Text nextButton = null;

    // 초기 체력 멤버변수
    private float originMyHp = 10f;
    private float originEnemyHp = 10f;
    private float currentMyHp = 0f;
    private float currentEnemyHp = 0f;

    // 게임 시작시 초기화
    private void Start() {
        this.myHp_Observer.Init(this.hp_Subject);
        this.enemyHp_Observer.Init(this.hp_Subject);

        this.originMyHp = 10f;
        this.originEnemyHp = 10f;

        this.currentMyHp = this.originMyHp;
        this.currentEnemyHp = this.originEnemyHp;

        // 옵저버의 등록
        this.hp_Subject.RegisterObserver(this.myHp_Observer);
        this.hp_Subject.RegisterObserver(this.enemyHp_Observer);

        // 옵저버들의 초기화
        this.hp_Subject.Changed(this.currentMyHp / this.originMyHp, this.currentEnemyHp / this.originEnemyHp);
    }

    // 버튼 동작시 호출
    public void Next() {
        if (this.currentMyHp <= 0f || this.currentEnemyHp <= 0f) {
            Debug.Log("--- 전투 종료 ---"); return;
        }

        // 랜덤하게 타겟 지정
        int attackIndex = Random.Range(0, 2);

        switch (attackIndex) {
            case 0:
                // 내가 공격
                this.currentEnemyHp -= 1f;
                Debug.Log("-내가 공격했다.");
                break;
            case 1:
                // 적이 공격
                this.currentMyHp -= 1f;
                Debug.Log("-적이 공격했다.");
                break;
            default:
                // 예외 처리
                Debug.Log("-에러가 발생했다!");
                break;
        }

        // 결과값 업데이트
        this.hp_Subject.Changed(this.currentMyHp / this.originMyHp, this.currentEnemyHp / this.originEnemyHp);
        Debug.Log($"내 체력 : {this.currentMyHp} / 상대 체력 : {this.currentEnemyHp}");

        if (this.currentMyHp <= 0f) {
            this.nextButton.text = "상대 승리";
            Debug.Log("---상대 승리---");
        }
        else if (this.currentEnemyHp <= 0f) {
            this.nextButton.text = "나의 승리";
            Debug.Log("---나의 승리---");
        }
        else {
            this.nextButton.text = "다음 턴";
        }
    }
    */
}