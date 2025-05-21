// ==========================================================================
// Copyright (C) 2022 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 20/03/2022 @ 20:11
// ==========================================================================

using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement; // 더 이상 사용하지 않으므로 제거

namespace NoSuchCompany.Games.SuperMario.Services.Impl
{
    // I need to find a way to inject this. Does Unity have DI? (참고: Zenject 등 사용 가능)
    internal sealed class LevelManager : ILevelManager
    {
        private static ILevelManager s_instance;

        private static readonly List<string> Levels = new List<string>
        {
            // 씬 이름 목록은 유지 가능. 단, 더 이상 사용되지 않음
            "Level 1-2",
            "Level 1-3",
            "Level 2-1"
        };

        public static ILevelManager Instance
        {
            get
            {
                if (s_instance is null)
                    s_instance = new LevelManager();

                return s_instance;
            }
        }

        private int _currentLevel;

        private LevelManager()
        {
            _currentLevel = 0;
        }

        public void LoadNextLevel()
        {
            _currentLevel++;
            LoadCurrentLevel(); // 여전히 호출되지만, 내부에서 씬 전환은 하지 않음
        }

        public void ReloadCurrentLevel()
        {
            LoadCurrentLevel(); // 동일
        }

        private void LoadCurrentLevel()
        {
            // 씬 전환 기능 비활성화
            if (_currentLevel < 0 || _currentLevel >= Levels.Count)
            {
                UnityEngine.Debug.LogWarning($"잘못된 레벨 인덱스: {_currentLevel}");
                return;
            }

            string levelName = Levels[_currentLevel];
            UnityEngine.Debug.Log($"LevelManager: '{levelName}' 로딩 요청됨 (하지만 실제로는 씬을 로드하지 않음)");
            // SceneManager.LoadScene(levelName); // 제거됨
        }
    }
}
