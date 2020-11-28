using UnityEngine;

public class MoveFigure : MonoBehaviour
{
    private Transform _transform;
    private float _moveSpeed;

    void Start()
    {
        _moveSpeed = GameSettings.instance.MoveSpeedFigure;
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
         _transform.Translate(new Vector3(1, 0, 0) * _moveSpeed * Time.fixedDeltaTime);
    }
}
