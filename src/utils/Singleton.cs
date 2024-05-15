namespace FarmerLib.utils;

public class Singleton<T> where T : new()
{
    private static T _instance;
    public static T Instance => _instance ??= new T();
}
