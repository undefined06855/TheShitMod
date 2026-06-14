using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TheShitMod.Components
{
    class BeingWashedComponent : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(WashingCycle());
        }

        public float m_elapsed = 0f;
        public float m_duration = 2f;

        IEnumerator WashingCycle()
        {
            while (m_elapsed < m_duration)
            {
                float dr = 360f / m_duration; // rotation per second

                gameObject.transform.Rotate(0f, 0f, dr * Time.deltaTime);

                m_elapsed += Time.deltaTime;
                yield return null;
            }

            UnityEngine.Object.Destroy(this);
        }
    }
}
