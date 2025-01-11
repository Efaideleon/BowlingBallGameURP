using UnityEngine;

[CreateAssetMenu(fileName = "PinConfig", menuName = "BowlingBall/PinConfig")]
public class PinConfig : ScriptableObject
{
    [Header("Configuration")]
    [SerializeField] private int _minimumLinearVelocity = 1;
    [SerializeField] private int _minimumAngularVelocity = 5;
    [SerializeField] private float _fallThreshold = 0.4f;

    public int MinimumLinearVelocity => _minimumLinearVelocity;
    public int MinimumAngularVelocity => _minimumAngularVelocity;
    public float FallThreshold => _fallThreshold;
}