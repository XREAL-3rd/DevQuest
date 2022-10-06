using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject ExplosionFx;

    [SerializeField]
    private float speed;
    private float magicalDamage;
    public float MagicalDamage { set { magicalDamage = value; } }

    private void OnEnable() {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        Vector3 direction = SetDirection();
        Quaternion rotation = SetRotation(direction);

        this.transform.rotation = rotation;
        rigidbody.AddForce(direction * speed);
    }

    private Vector3 SetDirection() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Vector3 direction;
        
        if (Physics.Raycast(ray, out hit) && !hit.transform.CompareTag("Player"))
            direction = ray.direction * hit.distance - (transform.position - ray.origin);
        else
            direction = ray.direction * 30 - (transform.position - ray.origin);
        
        return direction.normalized;
    }

    private void Update() {
        Vector3 direction = SetDirection();
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        Debug.DrawRay(transform.position, transform.up, Color.red);
    }

    private Quaternion SetRotation(Vector3 direction) {
        Vector3 cross = Vector3.Cross(direction, transform.right);
        return Quaternion.LookRotation(cross, Vector3.back);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player"))
            return;
        if (collision.transform.CompareTag("Target"))
            collision.transform.GetComponent<TargetHealth>().GetFireBallAttacked(magicalDamage);

        Instantiate(ExplosionFx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
