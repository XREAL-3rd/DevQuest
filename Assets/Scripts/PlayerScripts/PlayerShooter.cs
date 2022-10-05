using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] public GameObject Projectile;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;
    [SerializeField] private Transform shootOrigin;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput(){
        if (Input.GetButtonDown("Fire1")){
            RayAttack();
        }
        else if (Input.GetButtonDown("Fire2")){
            CollisionAttack();
        }
        // 다른 스킬들 추가 예정
    }

    private void RayAttack(){

    }

    private void CollisionAttack(){

    }

}
