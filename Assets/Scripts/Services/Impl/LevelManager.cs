// ==========================================================================
// Copyright (C) 2022 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 20/03/2022 @ 20:11
// ==========================================================================

using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement; // �� �̻� ������� �����Ƿ� ����

namespace NoSuchCompany.Games.SuperMario.Services.Impl
{
    // I need to find a way to inject this. Does Unity have DI? (����: Zenject �� ��� ����)
    internal sealed class LevelManager : ILevelManager
    {
        private static ILevelManager s_instance;

        private static readonly List<string> Levels = new List<string>
        {
            // �� �̸� ����� ���� ����. ��, �� �̻� ������ ����
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
            LoadCurrentLevel(); // ������ ȣ�������, ���ο��� �� ��ȯ�� ���� ����
        }

        public void ReloadCurrentLevel()
        {
            LoadCurrentLevel(); // ����
        }

        private void LoadCurrentLevel()
        {
            // �� ��ȯ ��� ��Ȱ��ȭ
            if (_currentLevel < 0 || _currentLevel >= Levels.Count)
            {
                UnityEngine.Debug.LogWarning($"�߸��� ���� �ε���: {_currentLevel}");
                return;
            }

            string levelName = Levels[_currentLevel];
            UnityEngine.Debug.Log($"LevelManager: '{levelName}' �ε� ��û�� (������ �����δ� ���� �ε����� ����)");
            // SceneManager.LoadScene(levelName); // ���ŵ�
        }
    }
}
