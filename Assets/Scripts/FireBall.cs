using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject ExplosionFx;
    public float speed = 0.01f;

    new private Rigidbody rigidbody;
    private Ray ray;
    private Vector3 direction;

    private void OnEnable() {
        rigidbody = GetComponent<Rigidbody>();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        direction = ray.direction * speed;
        rigidbody.AddForce(direction);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            return;
        if (other.CompareTag("Target"))
            other.transform.GetComponent<TargetHealth>().GetFireBallAttacked();

        Instantiate(ExplosionFx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player"))
            return;
        if (collision.transform.CompareTag("Target"))
            collision.transform.GetComponent<TargetHealth>().GetFireBallAttacked();

        Instantiate(ExplosionFx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
