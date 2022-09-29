using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
	public Slider hpbar;
	public int hp = 200;
	public Rigidbody rg;
	public int thrust = 5;
	
    public void attack(int damage, Vector3 shoot)
	{
		hpbar.gameObject.SetActive(true);
		hp -= (int)((float)damage / shoot.magnitude * thrust);
		hpbar.value = (float)hp/200;
		rg.AddForce(shoot.normalized *(thrust / shoot.magnitude), ForceMode.Impulse);
		if (hpbar.value <= 0) Destroy(this.gameObject);		
	}
}
