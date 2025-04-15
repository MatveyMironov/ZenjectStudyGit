using InputSystem;
using ShooterSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private InputListener inputListener;

        public override void InstallBindings()
        {
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle();

            Container.Bind<Shooter>().FromNew().AsSingle();

            Container.Bind<IBulletProvider>().To<BulletPoolProvider>().FromNew().AsSingle();
            Container.Bind<BulletPool>().FromInstance(bulletPool).AsSingle();

            Container.Bind<IPositionProvider>().To<TransformPositionProvider>().FromNewComponentOn(firePoint.gameObject).AsSingle();
            Container.Bind<IRotationProvider>().To<TransformRotationProvider>().FromNewComponentOn(firePoint.gameObject).AsSingle();

            Container.Bind<IBulletParametersProvider>().To<BulletParametersProvider>().FromInstance(new(bulletSpeed)).AsSingle();
        }
    }
}