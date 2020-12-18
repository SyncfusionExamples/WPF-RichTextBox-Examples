using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Custom_Suggestion_Provider
{
    internal class AppTypeSuggestionProvider : DependencyObject, ISuggestionProvider
    {

        #region Property
        public char MentionCharacter
        {
            get
            {
                return (char)GetValue(MentionCharacterProperty);
            }
            set
            {
                SetValue(MentionCharacterProperty, value);
            }
        }

        public Style SuggestionBoxStyle
        {
            get
            {
                return (Style)GetValue(SuggestionBoxStyleProperty);
            }
            set
            {
                SetValue(SuggestionBoxStyleProperty, value);
            }
        }

        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static DependencyProperty MentionCharacterProperty
        {
            get
            {
                return mentionCharacterProperty;
            }
        }

        public static DependencyProperty ItemsSourceProperty
        {
            get
            {
                return itemsSourceProperty;
            }
        }

        public static DependencyProperty SuggestionBoxStyleProperty
        {
            get
            {
                return suggestionBoxStyleProperty;
            }
        }
        #endregion

        #region Static Dependency Properties
        /// <summary>
        /// Identifies the MentionCharacter dependency property.
        /// </summary>
        private static DependencyProperty mentionCharacterProperty = DependencyProperty.Register("MentionCharacter", typeof(char), typeof(NameSuggestionProvider), new PropertyMetadata('@'));

        /// <summary>
        /// Identifies the ItemSource dependency property.
        /// </summary>
        private static DependencyProperty itemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(NameSuggestionProvider), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the SuggestionBoxStyle dependency property.
        /// </summary>
        private static DependencyProperty suggestionBoxStyleProperty = DependencyProperty.Register("SuggestionBoxStyle", typeof(Style), typeof(NameSuggestionProvider), new PropertyMetadata(null));
        #endregion

        public void Dispose()
        {
            ClearValue(mentionCharacterProperty);
            if (ItemsSource != null)
            {
                foreach (NameSuggestionItem itemSource in ItemsSource)
                {
                    itemSource.Dispose();
                }
                ClearValue(itemsSourceProperty);
            }
            ClearValue(suggestionBoxStyleProperty);
        }

        public void InsertSelectedItem(SfRichTextBoxAdv richTextBoxAdv, object selectedItem)
        {
            NameSuggestionItem nameSuggestionItem = selectedItem as NameSuggestionItem;
            richTextBoxAdv.Selection.InsertText(MentionCharacter + nameSuggestionItem.Name);
        }

        public List<object> Search(string searchText)
        {
            List<object> matchedItems = new List<object>();
            foreach (NameSuggestionItem item in ItemsSource)
            {
                if (item.Name.ToUpperInvariant().StartsWith(searchText.ToUpperInvariant()))
                {
                    matchedItems.Add(item);
                }
            }
            return matchedItems;
        }
    }
}
