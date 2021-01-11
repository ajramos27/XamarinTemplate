using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to push onto the Navigation Stack
        /// </summary>
        /// <typeparam name="TViewModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TViewModelBase>(object navigationData = null, bool setRoot = false);
        
        /// <summary>
        /// Navigation method to pop off of the Nativagation Stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
