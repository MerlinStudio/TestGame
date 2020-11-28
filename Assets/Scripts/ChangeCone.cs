using UnityEngine;

public class ChangeCone : MonoBehaviour
{
    [SerializeField] private Mesh Cylinder;
    [SerializeField] private Mesh Cone;

    private Transform _transform;
    private MeshFilter _meshFilter;
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
        _meshFilter = GetComponent<MeshFilter>();
        _counter = Counter.instance.UpdateCount;
        _lossCounter = Counter.instance.UpdateLossCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _hitCount++;
            if(_hitCount % 2 == 1)  //_meshFilter.mesh == Cone 
            {
                _meshFilter.mesh = Cylinder;
            }
            else _meshFilter.mesh = Cone;


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
