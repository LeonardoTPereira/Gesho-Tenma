using System;
using Weapons;

namespace Events
{
    public delegate void BulletHitEventHandler(object sender, BulletHitEventArgs eventArgs);
    public class BulletHitEventArgs : EventArgs
    {
        public BulletSo Bullet { get; set; }

        public BulletHitEventArgs(BulletSo bullet)
        {
            Bullet = bullet;
        }
    }
}
