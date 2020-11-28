using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private Transform _transform;
    private float _powerGun;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _powerGun = GameSettings.instance.PowerShoote;
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.AddForce(transform.forward * _powerGun, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Figura") || other.CompareTag("Floor"))
        {
            CreateExplosion.instance.ExplosionBullet(_transform);
            Destroy(gameObject);
        }
    }
}
