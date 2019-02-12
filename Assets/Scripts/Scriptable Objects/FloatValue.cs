using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = null, menuName = "Scriptable Objects/Float Value", order = 0)]
    public class FloatValue : ScriptableObject
    {
        public float value;
        public float constantValue;

        [SerializeField] bool useConstant;

        public FloatValue()
        {
            if (useConstant)
            {
                value = constantValue;
            }
        }
    }
}