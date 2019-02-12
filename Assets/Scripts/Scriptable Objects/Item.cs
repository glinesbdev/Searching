using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = null, menuName = "Scriptable Objects/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public GameObject value;
    }
}