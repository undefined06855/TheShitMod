using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TheShitMod.Components
{
    class GreenComponent : ReversibleColorEffect
    {
        new public void Start()
        {
            base.Start();
            SetColor(new Color(0f, 1f, 0f));
        }
    }
}
