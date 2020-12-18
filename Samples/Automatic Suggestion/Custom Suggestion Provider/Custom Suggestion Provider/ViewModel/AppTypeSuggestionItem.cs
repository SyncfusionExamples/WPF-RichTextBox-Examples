using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Automatic_Suggestion
{
    internal class AppTypeSuggestionItem : DependencyObject
    {

        #region Properties
        /// <summary>
        /// Gets or sets a value for <see cref="AppType"/> instance.
        /// </summary>
        public static DependencyProperty AppTypeProperty
        {
            get
            {
                return appTypeProperty;
            }
        }

        public string AppType
        {
            get
            {
                return (string)GetValue(AppTypeProperty);
            }
            set
            {
                SetValue(AppTypeProperty, value);
            }
        }

        #endregion

        #region Static Dependency Properties
        /// <summary>
        /// Identifies the app type dependency property.
        /// </summary>
        private static DependencyProperty appTypeProperty = DependencyProperty.Register("Name", typeof(string), typeof(AppTypeSuggestionItem), new PropertyMetadata(string.Empty));
        #endregion

        internal void Dispose()
        {
            ClearValue(appTypeProperty);
        }
    }
}
