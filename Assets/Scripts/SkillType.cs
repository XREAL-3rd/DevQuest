using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Type", order = 0)]
public class SkillType : ScriptableObject
{
    [SerializeField] private GameObject attackVFX;
    public GameObject AttackVFX => attackVFX;

    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private float radius;
    public float Radius => radius;

    [SerializeField] private float duration;
    public float Duration => duration;

    public IEnumerator SkillCoroutine(Vector3 pos)
    {
        float time = 0;
        while (Duration >= time)
        {
            time += Time.fixedDeltaTime;
            var hits = Physics.OverlapSphere(pos, Radius, LayerMask.GetMask("Ground"));
            foreach (var hit in hits)
            {
                var target = hit.GetComponent<Target>();
                if (target != null) target.Damage(Damage / Duration * Time.fixedDeltaTime);
            }

            yield return new WaitForFixedUpdate();
        }
    }
}