﻿#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

#endregion

namespace DMT.Controls
{
    /// <summary>
    /// Enter Key Traversal Util class.
    /// </summary>
    public class EnterKeyTraversal
    {
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        static void ue_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var ue = e.OriginalSource as FrameworkElement;
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null) return;

            ue.Unloaded -= ue_Unloaded;
            ue.PreviewKeyDown -= ue_PreviewKeyDown;
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
            typeof(EnterKeyTraversal), new UIPropertyMetadata(false, IsEnabledChanged));

        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ue = d as FrameworkElement;
            if (ue == null) return;

            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.PreviewKeyDown += ue_PreviewKeyDown;
            }
            else
            {
                ue.PreviewKeyDown -= ue_PreviewKeyDown;
            }
        }
    }

    public class TextBoxAutoSelect
    {
        public static readonly DependencyProperty HighlightTextOnFocusProperty =
            DependencyProperty.RegisterAttached("HighlightTextOnFocus",
            typeof(bool), typeof(TextBoxAutoSelect),
            new PropertyMetadata(false, HighlightTextOnFocusPropertyChanged));


        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetHighlightTextOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(HighlightTextOnFocusProperty);
        }

        public static void SetHighlightTextOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(HighlightTextOnFocusProperty, value);
        }

        private static void HighlightTextOnFocusPropertyChanged(
                DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var sender = obj as UIElement;
            if (sender != null)
            {
                if ((bool)e.NewValue)
                {
                    sender.GotKeyboardFocus += OnKeyboardFocusSelectText;
                    sender.PreviewMouseLeftButtonDown += OnMouseLeftButtonDownSetFocus;
                }
                else
                {
                    sender.GotKeyboardFocus -= OnKeyboardFocusSelectText;
                    sender.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDownSetFocus;
                }
            }
        }

        private static void OnKeyboardFocusSelectText(
            object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
            {
                textBox.SelectAll();
            }
        }

        private static void OnMouseLeftButtonDownSetFocus(
            object sender, MouseButtonEventArgs e)
        {
            TextBox tb = FindAncestor<TextBox>((DependencyObject)e.OriginalSource);

            if (tb == null)
                return;

            if (!tb.IsKeyboardFocusWithin)
            {
                tb.Focus();
                e.Handled = true;
            }
        }

        static T FindAncestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            current = VisualTreeHelper.GetParent(current);

            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            };
            return null;
        }
    }
}
