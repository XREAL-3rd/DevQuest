using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //공격 당하는 애들한테 일괄적으로 DamageMessage 주기
    bool ApplyDamage(DamageMessage damageMessage);
}
