﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using DesignPatternsWpf.Annotations;

namespace Infrastructures.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region DataMembers

        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        #endregion

        #region Properties

        protected Dictionary<string, object> Properties
        {
            get { return _properties; }
        }

        #endregion

        #region Methods

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(params Expression<Func<T>>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var memberExpression =
                    (MemberExpression) expression.Body;
                OnPropertyChanged(memberExpression.Member.Name);
            }
        }

        protected virtual T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (!_properties.ContainsKey(propertyName))
            {
                _properties.Add(propertyName, default(T));
            }
            return (T) _properties[propertyName];
        }

        protected virtual bool SetProperty<T>(T value, Expression<Func<T>> currentExpression,
                                              params Expression<Func<T>>[] otherExpressions)
        {
            var memberExpression =
                (MemberExpression) currentExpression.Body;
            string propertyName = memberExpression.Member.Name;
            var oldValue = GetProperty<T>(propertyName);
            bool changed = !EqualityComparer<T>.Default.Equals(oldValue, value);

            if (changed)
            {
                _properties[propertyName] = value;
                OnPropertyChanged(propertyName);
                OnPropertyChanged(otherExpressions);
            }

            return changed;
        }

        #endregion
    }
}