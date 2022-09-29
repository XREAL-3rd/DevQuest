using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float lifetime = 15;
        [SerializeField] private float damage = 20;
        [SerializeField] private ParticleSystem hitVFX;

        private float time;

        private void OnCollisionEnter(Collision collision)
        {
            var target = collision.gameObject.GetComponent<Target>();
            if (target != null)
            {
                Instantiate(hitVFX, transform.position, transform.rotation);
                target.Damage(20);
            }

            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            time += Time.fixedDeltaTime;
            if (transform.position.y < 0)
            {
                Destroy(gameObject);
                Instantiate(hitVFX, transform.position, transform.rotation);
            }
            else if (time >= lifetime) Destroy(gameObject);
        }
    }
}