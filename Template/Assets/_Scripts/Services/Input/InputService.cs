using UnityEngine;

namespace _Scripts.Services.Input
{
    public abstract class InputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector3 Axis { get; }


        protected static Vector3 SimpleInputAxis()
        {
            return new Vector3(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
    }
}