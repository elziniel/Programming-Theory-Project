using UnityEngine;

[CreateAssetMenu(fileName = "WeaponType", menuName = "Weapon")]
public class WeaponType : ScriptableObject
{
    public FloatReference fireRate;
    public FloatReference travelSpeed;
    public FloatReference travelDistance;
    public FloatReference precision;
}
