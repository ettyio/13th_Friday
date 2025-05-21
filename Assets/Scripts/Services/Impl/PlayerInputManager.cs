using UnityEngine;

namespace NoSuchCompany.Games.SuperMario.Services.Impl
{
    internal sealed class PlayerInputManager : IInputManager
    {
        public bool IsLeftPressed => Input.GetKey(KeyCode.A);

        public bool IsRightPressed => Input.GetKey(KeyCode.D);

        public bool IsJumpPressed => Input.GetKey(KeyCode.Space);

        public bool IsRunPressed => Input.GetKey(KeyCode.LeftShift);

        public Vector2 Direction => new Vector2(
            IsLeftPressed ? -1f : IsRightPressed ? 1f : 0f,
            0f
        );
    }
}
