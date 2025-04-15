using ShooterSystem;

public class BulletParametersProvider : IBulletParametersProvider
{
    private float _bulletSpeed;

    public BulletParametersProvider(float bulletSpeed)
    {
        _bulletSpeed = bulletSpeed;
    }

    public float GetBulletSpeed()
    {
        return _bulletSpeed;
    }
}
