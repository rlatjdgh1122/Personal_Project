using UnityEngine;

public interface IAIDamageable
{
    public void OnDamage(int damage, Vector3 point, Vector3 normal);
}
public interface IDamageable
{
    public void OnDamage(int damage);
}