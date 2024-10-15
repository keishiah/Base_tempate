using UnityEngine;

namespace _Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis => SimpleInputAxis();
    }
}