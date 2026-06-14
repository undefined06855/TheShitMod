using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TheShitMod.Components
{
    class TempSizeChangeComponent : MonoBehaviour
    {
        public void Start()
        {
            UnityEngine.Debug.Log("begin scale change");
            UnityEngine.Debug.Log(m_scaleChange);
            StartCoroutine(Shit());
        }

        public float m_scaleChange = 1f;

        IEnumerator Shit()
        {
            gameObject.transform.localScale *= m_scaleChange;

            float timer = 0f;

            while (timer < 2f)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            gameObject.transform.localScale /= m_scaleChange;

            UnityEngine.Object.Destroy(this);
        }
    }
}
