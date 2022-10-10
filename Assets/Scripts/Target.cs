using System;
using UnityEngine;

//Target 용 script
public class Target : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] private float health;

    private Collider colli;
    private Fill bar;
    private float barShowTime;

    //생성되면 자신을 Game에 등록
    private void OnEnable()
    {
        health = maxHealth;
        Game.Instance.AddTarget(this);
        colli = GetComponent<Collider>();
        bar = Bars.GetBar();
        UpdateBar();
        bar.Value = 1;
    }

    private void FixedUpdate()
    {
        if (barShowTime > 0) barShowTime -= Time.fixedDeltaTime;
        UpdateBar();
    }

    private void UpdateBar()
    {
        var barWorldPos = transform.position;
        barWorldPos.y = colli.bounds.max.y;
        //타겟 머리꼭대기 지점을 bar 위치로
        var barPos = Camera.main.WorldToScreenPoint(barWorldPos);
        var dist = Vector3.Distance(Game.Instance.Player.transform.position, transform.position);
        //거리가 멀면서 최근 맞지 않았거나, ui z좌표가 음수면 가리기
        if (barPos.z < 0 || dist > 20 && barShowTime <= 0) bar.Show(false);
        else
        {
            bar.Show(true);
            //거리비례 크기조절
            bar.UpdatePos(barPos, 1600 / dist, 200 / dist);
        }
    }

    //죽으면 자신을 Game에서 등록해제
    public void Damage(float amount)
    {
        health -= amount;
        barShowTime = 6;
        bar.Value = health / maxHealth;
        if (health <= 0)
        {
            Game.Instance.RemoveTarget(this);
            Bars.ReleaseBar(bar);
            Destroy(gameObject);
        }
    }
}