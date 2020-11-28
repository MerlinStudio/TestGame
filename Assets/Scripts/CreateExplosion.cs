using UnityEngine;

public class CreateExplosion : MonoBehaviour
{
    public static CreateExplosion instance = null;

    [SerializeField] private GameObject PrefabExplosion;
    [SerializeField] private GameObject PrefabExplosionBullet;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Explosion(Transform transform)
    {
        Instantiate(PrefabExplosion, transform.position, Quaternion.identity);
    }

    public void ExplosionBullet(Transform transform)
    {
        Instantiate(PrefabExplosionBullet, transform.position, Quaternion.identity);
    }
}
