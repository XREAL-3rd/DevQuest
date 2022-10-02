using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject ExplosionFx;
    [SerializeField]
    private float speed;

    private float magicalDamage;
    public float MagicalDamage { set { magicalDamage = value; } }

    new private Rigidbody rigidbody;
    private Ray ray;
    private Vector3 direction;

    private void OnEnable() {
        float distance = Vector3.Distance(GameObject.Find("AttackPoint").transform.position, GameObject.Find("Sphere").transform.position);
        rigidbody = GetComponent<Rigidbody>();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Vector3 direction;

        if (Physics.Raycast(ray, out hit) && !hit.transform.CompareTag("Player"))
            direction = ray.direction * hit.distance - (transform.position - ray.origin);
        else
            direction = ray.direction * 30 - (transform.position - ray.origin);
        direction = direction.normalized * speed;
        rigidbody.AddForce(direction);
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
