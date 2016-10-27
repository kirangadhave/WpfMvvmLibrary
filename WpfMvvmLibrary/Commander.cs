using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmLibrary
{
    public class Commander : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Event Handler to fire canExecute Change event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Constructor for canExecute check. Will execute if canExecute returns true.
        /// </summary>
        /// <param name="execute">Action</param>
        /// <param name="canExecute">Bool check for execution</param>
        public Commander(Action<object> execute, Func<object,bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || (_canExecute?.Invoke(parameter) ?? default(bool));
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
