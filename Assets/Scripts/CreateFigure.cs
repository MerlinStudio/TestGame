using System.Collections;
using UnityEngine;

public class CreateFigure : MonoBehaviour
{
    [SerializeField] private GameObject PrefabCube;
    [SerializeField] private GameObject PrefabSphere;
    [SerializeField] private GameObject PrefabCone;
    [SerializeField] private GameObject PrefabCar;

    [SerializeField] private Vector3 startPositionCube;
    [SerializeField] private Vector3 startPositionShere;
    [SerializeField] private Vector3 startPositionCone;
    [SerializeField] private Vector3 correctStartPosition;

    private float _delayCreatigCube;
    private float _delayCreatigSphere;
    private float _delayCreatigCone;

    void Start()
    {
        _delayCreatigCube = GameSettings.instance.DelayCreatigCube;
        _delayCreatigSphere = GameSettings.instance.DelayCreatigSphere;
        _delayCreatigCone = GameSettings.instance.DelayCreatigCone;

        StartCoroutine(CreatingCube(_delayCreatigCube));
        StartCoroutine(CreatingSphere(_delayCreatigSphere));
        StartCoroutine(CreatingCone(_delayCreatigCone));
    }

    IEnumerator CreatingCube(float delayCreatigCube)
    {
        yield return new WaitForSeconds(delayCreatigCube);
        Criating(PrefabCube, startPositionCube);
        StartCoroutine(CreatingCube(_delayCreatigCube));
    }
    IEnumerator CreatingSphere(float delayCreatigCube)
    {
        yield return new WaitForSeconds(delayCreatigCube);
        Criating(PrefabSphere, startPositionShere);
        StartCoroutine(CreatingSphere(_delayCreatigSphere));
    }
    IEnumerator CreatingCone(float delayCreatigCube)
    {
        yield return new WaitForSeconds(delayCreatigCube);
        Criating(PrefabCone, startPositionCone);
        StartCoroutine(CreatingCone(_delayCreatigCone));
    }

    private void Criating(GameObject Prefab, Vector3 StartPosition)
    {
        Instantiate(Prefab, StartPosition, Quaternion.identity);
        Instantiate(PrefabCar, StartPosition - correctStartPosition, Quaternion.identity);
    }
}
