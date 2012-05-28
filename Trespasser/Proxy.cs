using System;

namespace Trespasser
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;

    public class Proxy : DynamicObject
    {
        private readonly object _target;
        private readonly Type _targetType;

        private Proxy(object target)
        {
            _target = target;
            _targetType = target.GetType();
        }

        protected Proxy(Type targetType)
        {
            _targetType = targetType;
        }

        protected virtual BindingFlags BindingFlags
        {
            get
            {
                return BindingFlags.NonPublic |
                       BindingFlags.Instance |
                       BindingFlags.Static |
                       BindingFlags.Public;
            }
        }

        public static dynamic Create(object target)
        {
            return new Proxy(target);
        }

        public static dynamic Static<T>()
        {
            return new Proxy<T>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            MethodInfo method = null;

            if (!args.Any())
            {
                method = FindMethod(_targetType, binder.Name);
            }
            else if (!args.Contains(null))
            {
                var argTypes = args.Select(a => a.GetType()).ToArray();
                method = FindMethod(_targetType, binder.Name, argTypes);
            }
            else
            {
                var argCount = args.Count();
                var methods = FindMethods(_targetType);
                var possibleMatches =
                    methods.Where(m => String.Compare(m.Name, binder.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
                        .Where(m =>
                               {
                                   var parameters = m.GetParameters();
                                   return parameters.Count() == argCount &&
                                          ParameterTypesMatch(parameters, args);
                               })
                        .ToList();

                if (possibleMatches.Count() == 1)
                {
                    method = possibleMatches.Single();
                }
                else if (possibleMatches.Count() > 1)
                {
                    throw new AmbiguousMatchException(string.Format("Method '{0}' can be satisfied by multiple options",
                                                                    binder.Name));
                }
            }

            if (method != null)
            {
                result = method.Invoke(_target, args);
                return true;
            }

            return base.TryInvokeMember(binder, args, out result);
        }

        private MethodInfo FindMethod(Type target, string name)
        {
            if (target == null)
            {
                return null;
            }

            var method = target.GetMethod(name, BindingFlags);
            if (method != null)
            {
                return method;
            }

            return FindMethod(target.BaseType, name);
        }

        private MethodInfo FindMethod(Type target, string name, Type[] argTypes)
        {
            if (target == null)
            {
                return null;
            }

            var method = target.GetMethod(name, BindingFlags, null, argTypes, null);
            if (method != null)
            {
                return method;
            }

            return FindMethod(target.BaseType, name, argTypes);
        }

        private IEnumerable<MethodInfo> FindMethods(Type target)
        {
            if (target == null)
            {
                return new MethodInfo[] {};
            }
            return target.GetMethods(BindingFlags)
                .Concat(FindMethods(target.BaseType));
        }

        private bool ParameterTypesMatch(IList<ParameterInfo> parameterInfos, IEnumerable<object> args)
        {
            var argTypes = args.Select(obj => obj == null ? typeof (object) : obj.GetType()).ToArray();

            return parameterInfos.Select((info, index) =>
                                         argTypes[index].IsAssignableFrom(info.ParameterType) &&
                                         argTypes[index].IsClass == info.ParameterType.IsClass
                )
                .All(x => x);
        }


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var property = FindReadablProperty(_targetType, binder.Name);
            if (property != null)
            {
                result = property.GetValue(_target, null);
                return true;
            }

            var field = FindField(_targetType, binder.Name);
            if (field != null)
            {
                result = field.GetValue(_target);
                return true;
            }

            return base.TryGetMember(binder, out result);
        }

        private PropertyInfo FindReadablProperty(Type target, string name)
        {
            if (target == null)
            {
                return null;
            }

            var property = target.GetProperty(name, BindingFlags);
            if (property != null)
            {
                if (property.CanRead)
                {
                    return property;
                }
            }

            return FindReadablProperty(target.BaseType, name);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var property = FindWritableProperty(_targetType, binder.Name);
            if (property != null)
            {
                property.SetValue(_target, value, null);
                return true;
            }

            var field = FindField(_targetType, binder.Name);
            if (field != null)
            {
                field.SetValue(_target, value);
                return true;
            }

            return base.TrySetMember(binder, value);
        }

        private PropertyInfo FindWritableProperty(Type target, string name)
        {
            if (target == null)
            {
                return null;
            }

            var property = target.GetProperty(name, BindingFlags);
            if (property != null)
            {
                if (property.CanWrite)
                {
                    return property;
                }
            }

            return FindWritableProperty(target.BaseType, name);
        }

        private FieldInfo FindField(Type target, string name)
        {
            if (target == null)
            {
                return null;
            }

            var field = target.GetField(name, BindingFlags);
            if (field != null)
            {
                    return field;
            }

            return FindField(target.BaseType, name);
        }
    }
}