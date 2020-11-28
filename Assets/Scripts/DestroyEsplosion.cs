using UnityEngine;

public class DestroyEsplosion : MonoBehaviour
{
    void Start()
    {
        Invoke("Delay", 1);
    }
    
    private void Delay()
    {
        Destroy(gameObject);
    }
}
