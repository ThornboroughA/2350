using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance;

    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();

                if (Instance == null)
                {
                    GameObject singleton = new GameObject();
                    Instance = singleton.AddComponent<T>();
                    singleton.name = $"{typeof(T).ToString()} (Singleton)";

                    singleton.transform.SetParent(null);
                }
            }
            else
            {
                T[] instances = FindObjectsOfType<T>();
                if (instances.Length > 1)
                {
                    for (int i = 1; i < instances.Length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }
                }
            }

            return Instance;
        }
    }
}
