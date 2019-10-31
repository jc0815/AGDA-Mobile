using UnityEngine;

public class MonobehaviorSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>();
            return _instance;
        }
    }
}
