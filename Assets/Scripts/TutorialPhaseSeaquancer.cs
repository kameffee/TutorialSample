using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TutorialSample
{
    public class TutorialPhaseSeaquancer : MonoBehaviour
    {
        [SerializeField]
        private TutorialPhase[] _phases;

        [SerializeField]
        private int _currentPhase = 0;

        public event Action OnEnd;

        void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            gameObject.SetActive(false);

            foreach (var tutorialPhase in _phases)
            {
                tutorialPhase.Initialize();
            }
        }

        public void StartTutorial(int startIndex = 0)
        {
            if (startIndex < 0 || _phases.Length <= startIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            Debug.Log("チュートリアル開始");

            gameObject.SetActive(true);

            // 開く
            var targetPhase = _phases[startIndex];
            targetPhase.OnClickEvent += OnClickEnvet;
            targetPhase.Open();
        }

        public void NextPhase()
        {
            // 現在のフェーズを閉じる
            ClosePhase(_phases[_currentPhase]);

            _currentPhase++;

            var nextPhase = _phases[_currentPhase];
            nextPhase.Open();
            nextPhase.OnClickEvent += OnClickEnvet;
        }

        public bool HasNext()
        {
            return _currentPhase + 1 < _phases.Length;
        }

        private void ClosePhase(TutorialPhase targetPhase)
        {
            var opendPhase = targetPhase;
            opendPhase.OnClickEvent -= OnClickEnvet;
            opendPhase.Close();
        }

        private void OnClickEnvet()
        {
            if (HasNext())
            {
                NextPhase();
            }
            else
            {
                OnTutorialEnd();
            }
        }

        /// <summary>
        /// 終わった時
        /// </summary>
        private void OnTutorialEnd()
        {
            // 閉じる
            ClosePhase(_phases[_currentPhase]);

            gameObject.SetActive(false);
            
            Debug.Log("チュートリアル終了");

            OnEnd?.Invoke();
        }
    }
}
