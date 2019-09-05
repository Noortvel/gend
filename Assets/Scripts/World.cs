using UnityEngine;

public class World : MonoBehaviour
{
    private static World __world = null;

    [SerializeField]
    private Transform charater;

    public Transform Character
    {
        get
        {
            return charater;
        }
    }
    
    void Awake()
    {
        __world = this;
    }
    public static World GetInstance()
    {
        return __world;
    }
}
