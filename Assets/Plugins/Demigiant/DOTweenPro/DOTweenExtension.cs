/*
DOTweenExtension.cs
Date : 2023-12-13 10:46:39
*/

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DG.Tweening
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Extension/CCDotween")]
    [RequireComponent(typeof(DOTweenAnimation))]
    public class DOTweenExtension : MonoBehaviour
    {
        public bool RestartOnEnable = true;
        private DOTweenAnimation[] m_tweenArr;

        #region[Cycle]
        private void Awake()
        {
            m_tweenArr ??= this.GetComponents<DOTweenAnimation>();
        }
        private void OnEnable()
        {
            if (RestartOnEnable && m_tweenArr != null)
                OnRestart();
        }
        private void OnDisable()
        {
            if (m_tweenArr.Length > 0)
                foreach (var tween in m_tweenArr)
                    tween.DOPause();
        }
        #endregion

        #region[Method]
        public void OnRestart()
        {
            if (this.gameObject.activeInHierarchy == false)
                return;

            if (m_tweenArr.Length > 0)
            {
                foreach (var tween in m_tweenArr)
                {
                    // if (tween.tween == null)
                        // tween.RecreateTween();

                    tween.DORestart();
                }
            }
        }
        #endregion
    }
}