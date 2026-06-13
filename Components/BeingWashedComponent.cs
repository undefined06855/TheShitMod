using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TheShitMod.Components
{
    class BeingWashedComponent : MonoBehaviour
    {
        void Awake()
        {
            StartCoroutine(WashingCycle());
        }

        IEnumerator WashingCycle()
        {
            if (!base.GetComponent<GeneralInput>().controlledElseWhere)
            {
                Quaternion startRotation = Camera.main.gameObject.transform.rotation;
                Quaternion endRotation = Quaternion.Euler(new Vector3(0f, 0f, 360f));

                float elapsed = 0f;
                float duration = 2f;

                while (elapsed < duration)
                {
                    float t = elapsed / duration;
                    Camera.main.gameObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

                    elapsed += Time.deltaTime;
                    yield return null;
                }

                Camera.main.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                UnityEngine.Object.Destroy(this);
            }

            yield return null;
        }
    }
}
