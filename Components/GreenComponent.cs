using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TheShitMod.Components
{
    // so theoretically this should make the player green right
    // in reality this makes the player's limbs invisible ?? so that's a feature now i guess
    class GreenComponent : ReversibleColorEffect
    {
        new public void Start()
        {
            base.Start();
            SetColor(new Color(0f, 1f, 0f));
        }
    }
}
