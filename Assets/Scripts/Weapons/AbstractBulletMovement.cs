using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class AbstractBulletMovement : ScriptableObject
    {
        public abstract IEnumerator Move(Vector2 speed, BulletController bulletController);
    }
}
