using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    internal static class ComponentExtensions
    {
        public static T LogErrorIfNotAttached<T>(this T component) where T : Component
        {
            if (component == null)
            {
                Debug.LogError($"The {typeof(T).Name} is not attached.");
            }

            return component;
        }

        public static void Enable(this Behaviour component)
        {
            component.enabled = true;
        }

        public static void Disable(this Behaviour component)
        {
            component.enabled = false;
        }
    }
}
