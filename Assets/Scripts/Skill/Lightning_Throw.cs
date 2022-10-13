using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Throw : MonoBehaviour {
    public GameObject Lightning;

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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = ray.direction * 30 - (transform.position - ray.origin);
        return direction.normalized;
    }

    private Quaternion SetRotation(Vector3 direction) {
        Vector3 cross = Vector3.Cross(direction, transform.right);
        return Quaternion.LookRotation(cross, Vector3.back);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player"))
            return;

        Instantiate(Lightning, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
