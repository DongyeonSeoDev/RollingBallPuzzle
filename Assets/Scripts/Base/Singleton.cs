using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // 싱글톤을 관리하는 클래스
{
    public bool isDestroy = true;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (!(instance is null))
        {
            Debug.LogWarning(typeof(T) + "의 instance가 이미 있습니다.");
            Destroy(this);

            return;
        }

        instance = GetComponent<T>();
    }

    protected virtual void OnDestroy()
    {
        if (isDestroy)
        {
            instance = null;
        }
    }
}