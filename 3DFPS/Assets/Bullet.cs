using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 50.0f;
    public GameObject particlePrefab;
    public int damage = 10;
    public int particleCount = 10;
    public float particleSpeed = 10.0f;
    public float particleSpread = 45.0f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Monster zombie = hit.collider.GetComponent<Monster>();
                if (zombie != null)
                {

                    GameObject particle = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);
                    Rigidbody particleRigidbody = particle.GetComponent<Rigidbody>();

                    Vector3 particleMoveDirection = transform.position - hit.point;
                    particleMoveDirection.Normalize();

                    particleRigidbody.velocity = particleMoveDirection * particleSpeed;

                    Destroy(particle, 2.0f);
                    zombie.TakeDamage(damage);
                }
                Destroy(gameObject);

            }
            if (hit.collider.CompareTag("Map"))
            {


                GameObject particle = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);
                Debug.Log("Particle");
                Rigidbody particleRigidbody = particle.GetComponent<Rigidbody>();

                Vector3 particleMoveDirection = transform.position - hit.point;
                particleMoveDirection.Normalize();

                particleRigidbody.velocity = particleMoveDirection * particleSpeed;

                Destroy(particle, 2.0f);


                Destroy(gameObject);
            }
        }

        return;
    }
}

