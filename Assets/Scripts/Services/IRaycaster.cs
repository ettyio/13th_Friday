// ==========================================================================
// Copyright (C) 2022 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 25/03/2022 @ 19:11
// ==========================================================================

using System.Collections.Generic;
using NoSuchCompany.Games.SuperMario.Entities;
using UnityEngine;

namespace NoSuchCompany.Games.SuperMario.Services
{
    public interface IRaycaster
    {
        ICollisions Collisions { get; }

        const int DefaultRayCount = 3;  // 예시: 기본값 3
        void Initialize(Collider2D collider2D, int rayCounts = DefaultRayCount);

        IEnumerable<IRaycastCollision> FindVerticalHitsOnly(Vector2 objectVelocity, LayerMask collisionMask, float? fixedRayLength = null);

        void ApplyCollisions(ref Vector3 objectVelocity, LayerMask collisionMask);
    }
}