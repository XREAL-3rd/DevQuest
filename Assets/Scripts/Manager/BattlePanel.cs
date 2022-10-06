using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// ����� ��ũ��Ʈ
public class BattlePanel : MonoBehaviour {
    /*
    // ü�°��� Subject
    [SerializeField]
    private Hp_Subject hp_Subject = null;

    //��,��� ü�� Obsever 
    //[SerializeField]
    //private MyHp_Observer myHp_Observer = null;
    //[SerializeField]
    //private EnemyHp_Observer enemyHp_Observer = null;

    // ������ ���� ��ư
    [SerializeField]
    private Text nextButton = null;

    // �ʱ� ü�� �������
    private float originMyHp = 10f;
    private float originEnemyHp = 10f;
    private float currentMyHp = 0f;
    private float currentEnemyHp = 0f;

    // ���� ���۽� �ʱ�ȭ
    private void Start() {
        this.myHp_Observer.Init(this.hp_Subject);
        this.enemyHp_Observer.Init(this.hp_Subject);

        this.originMyHp = 10f;
        this.originEnemyHp = 10f;

        this.currentMyHp = this.originMyHp;
        this.currentEnemyHp = this.originEnemyHp;

        // �������� ���
        this.hp_Subject.RegisterObserver(this.myHp_Observer);
        this.hp_Subject.RegisterObserver(this.enemyHp_Observer);

        // ���������� �ʱ�ȭ
        this.hp_Subject.Changed(this.currentMyHp / this.originMyHp, this.currentEnemyHp / this.originEnemyHp);
    }

    // ��ư ���۽� ȣ��
    public void Next() {
        if (this.currentMyHp <= 0f || this.currentEnemyHp <= 0f) {
            Debug.Log("--- ���� ���� ---"); return;
        }

        // �����ϰ� Ÿ�� ����
        int attackIndex = Random.Range(0, 2);

        switch (attackIndex) {
            case 0:
                // ���� ����
                this.currentEnemyHp -= 1f;
                Debug.Log("-���� �����ߴ�.");
                break;
            case 1:
                // ���� ����
                this.currentMyHp -= 1f;
                Debug.Log("-���� �����ߴ�.");
                break;
            default:
                // ���� ó��
                Debug.Log("-������ �߻��ߴ�!");
                break;
        }

        // ����� ������Ʈ
        this.hp_Subject.Changed(this.currentMyHp / this.originMyHp, this.currentEnemyHp / this.originEnemyHp);
        Debug.Log($"�� ü�� : {this.currentMyHp} / ��� ü�� : {this.currentEnemyHp}");

        if (this.currentMyHp <= 0f) {
            this.nextButton.text = "��� �¸�";
            Debug.Log("---��� �¸�---");
        }
        else if (this.currentEnemyHp <= 0f) {
            this.nextButton.text = "���� �¸�";
            Debug.Log("---���� �¸�---");
        }
        else {
            this.nextButton.text = "���� ��";
        }
    }
    */
}