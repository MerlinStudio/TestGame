using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance = null;

    public float MoveSpeedFigure;

    [Space]
    public float DelayCreatigCube;
    public float DelayCreatigSphere;
    public float DelayCreatigCone;

    [Space]
    public float PowerShoote;
    public float[] DelayShoote;
    public GameObject[] Gun;

    [Space]
    public int CountForWin;
    public int CountForGameOver;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public float SetDelayShoot(GameObject gameObject)
    {
        float delayShoot = 0;
        for (int i = 0; i < Gun.Length; i++)
        {
            if(Gun[i] == gameObject)
            {
                delayShoot = DelayShoote[i];
            }
        }
        return delayShoot;
    }
}
