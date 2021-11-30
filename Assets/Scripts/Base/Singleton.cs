using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // �̱����� �����ϴ� Ŭ����
{
    public bool isDestroy = true;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance is null)
            {
                Debug.Log(typeof(T) + "�� instance�� null �Դϴ�.");
                return null;
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (!(instance is null))
        {
            Debug.LogWarning(typeof(T) + "�� instance�� �̹� �ֽ��ϴ�.");
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