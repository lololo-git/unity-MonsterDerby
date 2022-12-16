using UnityEngine;

[CreateAssetMenu]
public class Parameters: ScriptableObject
{
    [Header("Max speed of Bar")]
    [Range(0, 20)]
    public float BarMaxSpeed;

    [Header("Acceleration of Bar")]
    [Range(0, 20)]
    public float BarAcceleration;



    // Immplementation of Singleton
    public const string PATH = "Parameters";
    private static Parameters _instance;

    public static Parameters Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Parameters>(PATH);
                if (_instance == null)
                    Debug.LogError(PATH + " not found");
            }
            return _instance;
        }
    }
}