using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts
{
    public class DiContainer
    {
        private readonly Dictionary<Type, object> _singletons = new();

        public void Bind<T>(T instance)
        {
            _singletons[instance.GetType()] = instance;
        }

        public void Bind<T>()
        {
            _singletons[typeof(T)] = Activator.CreateInstance(typeof(T));
        }

        public void Inject(object instance)
        {
            var type = instance.GetType();
            var fields = type.GetFields(BindingFlags.Instance |
                                        BindingFlags.Public |
                                        BindingFlags.NonPublic)
                                       .Where(field => field.IsDefined(typeof(InjectAttribute), true));

            foreach (var field in fields)
            {
                if (_singletons.TryGetValue(field.FieldType, out var singleton))
                {
                    field.SetValue(instance, singleton);
                }
                else
                {
                    Debug.LogError($"Missing: {field.FieldType.Name} in {type.Name}");
                }
            }

            var methods = type.GetMethods(BindingFlags.Instance | 
                                          BindingFlags.Public | 
                                          BindingFlags.NonPublic)
                                         .Where(method => method.IsDefined(typeof(InjectAttribute), true));

            foreach (var method in methods)
            {
                var parameters = method.GetParameters();
            }
        }

        public void InjectAll()
        {
            foreach (var instance in _singletons.Values)
            {
                Inject(instance);
            }
        }

        private object[] ResolveAll(ParameterInfo[] parameters)
        {
            var args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                if (_singletons.TryGetValue(parameters[i].ParameterType, out var singleton))
                {
                    args[i] = singleton;
                }
            }

            return args;
        }
    }
}