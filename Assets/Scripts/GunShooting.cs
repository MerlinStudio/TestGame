using System.Collections;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private GameObject PrefabBullet;
    [SerializeField] private Transform Aim;

    private float _delayShoote;
    void Start()
    {
        _delayShoote = GameSettings.instance.SetDelayShoot(gameObject);
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(_delayShoote);
        Instantiate(PrefabBullet, Aim.position, Aim.rotation);
        StartCoroutine(Fire());
    }
}
