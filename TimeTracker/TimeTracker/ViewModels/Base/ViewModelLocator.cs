using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace TimeTracker.ViewModels.Base
{
    public class ViewModelLocator
    {
        static TinyIoCContainer _container; //init ioc container
        static Dictionary<Type, Type> _viewLookup; //to map our views to our viewmodels
        
        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            //Register pages and pages models

            //Register services (services are registered as Singletons by default)
        }

        public static T Resolve<T>() where T : class //T probably a ViewModel
        {
            return _container.Resolve<T>();
        }

        //create a page for specific view model type
        public static Page CreatePageFor(Type viewModelType)
        {
            var pageType = _viewLookup[viewModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var viewModel = _container.Resolve(viewModelType);

            page.BindingContext = viewModel;

            return page;
        }


    }
}
