// Copyright (C) 2012 Julien Lemoine. All rights reserved.
// Contact: contact (at) algolia.com
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.
//
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Documents;

namespace AlgoliaSearch
{
    /**
     * This class allows to bind a string with bold HTML tags(<b></b>) tags in a TextBlock on Windows 8.
     *
     * The highlighted part of Text property are rendered with HighlightBrush property.
     * 
     */
    public class HTMLBinding
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
            "Text",
            typeof(string),
            typeof(Binding),
            new PropertyMetadata(null, OnTextChangedCallback)
            );

        public static readonly DependencyProperty HighlightBrushProperty = DependencyProperty.RegisterAttached(
            "HighlightBrush",
            typeof(Brush),
            typeof(Binding),
            new PropertyMetadata(null, OnHighlightBrushChangedCallback)
        );

        private static void OnHighlightBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textBlock = d as TextBlock;
            if (textBlock == null)
            {
                return;
            }

            Brush brush = GetHighlightBrush(textBlock);

            for (int i = 0; i < textBlock.Inlines.Count; i += 2)
            {
                textBlock.Inlines[i].Foreground = brush;
            }
        }

        private static void OnTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textBlock = d as TextBlock;
            if (textBlock == null)
            {
                return;
            }
            string text = GetText(textBlock);

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Brush brush = GetHighlightBrush(textBlock) ?? new SolidColorBrush(Colors.Red);

            int lastIndex = 0;
            int index = text.IndexOf("<b>", 0, StringComparison.CurrentCulture);

            textBlock.Inlines.Clear();
            while (index >= 0)
            {
                textBlock.Inlines.Add(new Run { Text = text.Substring(lastIndex, index - lastIndex) });
                int endIndex = text.IndexOf("</b>", index + 3, StringComparison.CurrentCulture);
                textBlock.Inlines.Add(new Run { Text = text.Substring(index + 3, endIndex - index - 3), Foreground = brush });
                lastIndex = endIndex + 4;
                index = text.IndexOf("<b>", lastIndex, StringComparison.CurrentCulture);
            }
            textBlock.Inlines.Add(new Run { Text = text.Substring(lastIndex) });
        }

        public static void SetText(TextBlock element, string value)
        {
            element.SetValue(TextProperty, value);
        }

        public static string GetText(TextBlock element)
        {
            return (string)element.GetValue(TextProperty);
        }

        public static void SetHighlightBrush(TextBlock element, Brush value)
        {
            element.SetValue(HighlightBrushProperty, value);
        }

        public static Brush GetHighlightBrush(TextBlock element)
        {
            return (Brush)element.GetValue(HighlightBrushProperty);
        }
    }
}
