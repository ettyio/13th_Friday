// ==========================================================================
// Copyright (C) 2022 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 20/03/2022 @ 19:44
// ==========================================================================

using System.Linq;
using NoSuchCompany.Games.SuperMario.Constants;
using NoSuchCompany.Games.SuperMario.Diagnostics;
using NoSuchCompany.Games.SuperMario.Services;
using NoSuchCompany.Games.SuperMario.Services.Impl;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace NoSuchCompany.Games.SuperMario.Behaviors
{
    public class LevelBehavior : MonoBehaviour
    {
        //  Private fields.
        private readonly IRaycaster _raycaster;

        //  Unity injected properties.
        public LayerMask collisionMask;

        public LevelBehavior()
        {
            _raycaster = new Raycaster();
        }

        public void Start()
        {
            var tilemapCollider2D = GetComponent<TilemapCollider2D>();

            if (tilemapCollider2D != null)
            {
                _raycaster.Initialize(tilemapCollider2D, 3);
            }
            else
            {
                Debug.LogError("TilemapCollider2D not found on this GameObject.");
            }
        }

        public void Update()
        {
            Vector3 noMovement = Vector3.zero;
            _raycaster.ApplyCollisions(ref noMovement, collisionMask);

            AppLogger.Write(LogsLevels.None, $"Collisions: {_raycaster.Collisions.LeftCollisions.Count()}");
            
            if (_raycaster.Collisions.LeftCollisions.Contains(Tags.Player))
            {
                AppLogger.Write(LogsLevels.None, $"HIT!!!");
                LevelManager.Instance.LoadNextLevel();
            }
        }
    }
}