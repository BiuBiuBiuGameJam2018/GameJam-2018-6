using UnityEngine;

/// <summary>
/// 非MonoBehaviour的单例形式，需要自行添加类的公有无参构造函数
/// </summary>
public class Singleton<T> where T : new()
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
}

/// <summary>
/// MonoBehaviour的单例形式一，需要自行处理_instance的赋值和添加类的保护无参构造函数
/// </summary>
public class SingletonMono<T> : MonoBehaviour
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
}

/// <summary>
/// MonoBehaviour的单例形式二，无需关心加载对象本身时使用，脚本会自动加载
/// 所有此种形式的单例脚本，将会加载到名为IndependentSingletonMonoObject同一对象上
/// </summary>
public class IndependentSingletonMono<T> : MonoBehaviour where T : IndependentSingletonMono<T>
{
    static string IndependentSingletonMonoObject = "IndependentSingletonMonoObject";
    protected static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    var go = GameObject.Find(IndependentSingletonMonoObject);
                    if (go == null)
                        go = new GameObject(IndependentSingletonMonoObject);
                    _instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}

