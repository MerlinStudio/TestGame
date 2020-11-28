using UnityEngine;

public class ChangeCube : MonoBehaviour
{
    private Animation _animation;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private int _hitCount;

    delegate void Count();
    Count _counter;
    delegate void LossCount();
    Count _lossCounter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animation = GetComponent<Animation>();
        _counter = Counter.instance.UpdateCount;
        _lossCounter = Counter.instance.UpdateLossCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _animation.Play("CubeScale");

            _hitCount++;
            if (_hitCount == 3)
            {
                _counter();
                CreateExplosion.instance.Explosion(_transform);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Jump"))
        {
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        if (other.CompareTag("Destroy"))
        {
            _lossCounter();
            //CreateExplosion.instance.Explosion(_transform);
            Destroy(gameObject);
        }
    }
}
