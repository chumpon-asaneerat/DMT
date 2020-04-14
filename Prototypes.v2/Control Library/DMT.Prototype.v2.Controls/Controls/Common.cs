#region Using

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

    public static class NumericTextBox
    {
        #region Enum Declarations

        public enum NumericFormat
        {
            Double,
            Int,
            Uint,
            Natural
        }

        public enum EvenOddConstraint
        {
            All,
            OnlyEven,
            OnlyOdd
        }

        #endregion

        #region Dependency Properties & CLR Wrappers

        public static readonly DependencyProperty OnlyNumericProperty =
            DependencyProperty.RegisterAttached("OnlyNumeric", typeof(NumericFormat?), typeof(NumericTextBox),
                new PropertyMetadata(null, DependencyPropertiesChanged));
        public static void SetOnlyNumeric(TextBox element, NumericFormat value) =>
            element.SetValue(OnlyNumericProperty, value);
        public static NumericFormat GetOnlyNumeric(TextBox element) =>
            (NumericFormat)element.GetValue(OnlyNumericProperty);

        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.RegisterAttached("DefaultValue", typeof(string), typeof(NumericTextBox),
                new PropertyMetadata(null, DependencyPropertiesChanged));
        public static void SetDefaultValue(TextBox element, string value) =>
            element.SetValue(DefaultValueProperty, value);
        public static string GetDefaultValue(TextBox element) => (string)element.GetValue(DefaultValueProperty);

        public static readonly DependencyProperty EvenOddConstraintProperty =
            DependencyProperty.RegisterAttached("EvenOddConstraint", typeof(EvenOddConstraint), typeof(NumericTextBox),
                new PropertyMetadata(EvenOddConstraint.All, DependencyPropertiesChanged));
        public static void SetEvenOddConstraint(TextBox element, EvenOddConstraint value) =>
            element.SetValue(EvenOddConstraintProperty, value);
        public static EvenOddConstraint GetEvenOddConstraint(TextBox element) =>
            (EvenOddConstraint)element.GetValue(EvenOddConstraintProperty);

        #endregion

        #region Dependency Properties Methods

        private static void DependencyPropertiesChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TextBox textBox))
                throw new Exception("Attached property must be used with TextBox.");

            switch (e.Property.Name)
            {
                case "OnlyNumeric":
                    {
                        var castedValue = (NumericFormat?)e.NewValue;

                        if (castedValue.HasValue)
                        {
                            textBox.PreviewTextInput += TextBox_PreviewTextInput;
                            DataObject.AddPastingHandler(textBox, TextBox_PasteEventHandler);
                        }
                        else
                        {
                            textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                            DataObject.RemovePastingHandler(textBox, TextBox_PasteEventHandler);
                        }
                        break;
                    }
                case "DefaultValue":
                    {
                        var castedValue = (string)e.NewValue;
                        if (castedValue != null)
                        {
                            textBox.TextChanged += TextBox_TextChanged;
                        }
                        else
                        {
                            textBox.TextChanged -= TextBox_TextChanged;
                        }
                        break;
                    }
            }
        }

        #endregion

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;

            string newText;

            if (textBox.SelectionLength == 0)
            {
                newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            }
            else
            {
                var textAfterDelete = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);

                newText = textAfterDelete.Insert(textBox.SelectionStart, e.Text);
            }

            var evenOddConstraint = GetEvenOddConstraint(textBox);

            switch (GetOnlyNumeric(textBox))
            {
                case NumericFormat.Double:
                    {
                        if (double.TryParse(newText, out double number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:
                                    e.Handled = (number % 2 != 0);
                                    break;
                                case EvenOddConstraint.OnlyOdd:
                                    e.Handled = (number % 2 == 0);
                                    break;
                            }
                        }
                        else e.Handled = true;
                        break;
                    }

                case NumericFormat.Int:
                    {
                        if (int.TryParse(newText, out int number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:

                                    e.Handled = (number % 2 != 0);
                                    break;

                                case EvenOddConstraint.OnlyOdd:

                                    e.Handled = (number % 2 == 0);
                                    break;
                            }
                        }
                        else e.Handled = true;
                        break;
                    }

                case NumericFormat.Uint:
                    {
                        if (uint.TryParse(newText, out uint number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:

                                    e.Handled = (number % 2 != 0);
                                    break;

                                case EvenOddConstraint.OnlyOdd:

                                    e.Handled = (number % 2 == 0);
                                    break;
                            }
                        }
                        else e.Handled = true;
                        break;
                    }

                case NumericFormat.Natural:
                    {
                        if (uint.TryParse(newText, out uint number))
                        {
                            if (number == 0)
                                e.Handled = true;
                            else
                            {
                                switch (evenOddConstraint)
                                {
                                    case EvenOddConstraint.OnlyEven:

                                        e.Handled = (number % 2 != 0);
                                        break;

                                    case EvenOddConstraint.OnlyOdd:

                                        e.Handled = (number % 2 == 0);
                                        break;
                                }
                            }
                        }
                        else e.Handled = true;
                        break;
                    }
            }
        }

        private static void TextBox_PasteEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var clipboardText = (string)e.DataObject.GetData(typeof(string));

                var newText = textBox.Text.Insert(textBox.SelectionStart, clipboardText);

                var evenOddConstraint = GetEvenOddConstraint(textBox);

                switch (GetOnlyNumeric(textBox))
                {
                    case NumericFormat.Double:
                        {
                            if (double.TryParse(newText, out double number))
                            {
                                switch (evenOddConstraint)
                                {
                                    case EvenOddConstraint.OnlyEven:

                                        if (number % 2 != 0)
                                            e.CancelCommand();
                                        break;

                                    case EvenOddConstraint.OnlyOdd:

                                        if (number % 2 == 0)
                                            e.CancelCommand();
                                        break;
                                }
                            }
                            else e.CancelCommand();
                            break;
                        }

                    case NumericFormat.Int:
                        {
                            if (int.TryParse(newText, out int number))
                            {
                                switch (evenOddConstraint)
                                {
                                    case EvenOddConstraint.OnlyEven:

                                        if (number % 2 != 0)
                                            e.CancelCommand();
                                        break;
                                    case EvenOddConstraint.OnlyOdd:

                                        if (number % 2 == 0)
                                            e.CancelCommand();
                                        break;
                                }
                            }
                            else e.CancelCommand();
                            break;
                        }

                    case NumericFormat.Uint:
                        {
                            if (uint.TryParse(newText, out uint number))
                            {
                                switch (evenOddConstraint)
                                {
                                    case EvenOddConstraint.OnlyEven:

                                        if (number % 2 != 0)
                                            e.CancelCommand();
                                        break;
                                    case EvenOddConstraint.OnlyOdd:

                                        if (number % 2 == 0)
                                            e.CancelCommand();
                                        break;
                                }
                            }
                            else e.CancelCommand();
                            break;
                        }

                    case NumericFormat.Natural:
                        {
                            if (uint.TryParse(newText, out uint number))
                            {
                                if (number == 0) e.CancelCommand();
                                else
                                {
                                    switch (evenOddConstraint)
                                    {
                                        case EvenOddConstraint.OnlyEven:

                                            if (number % 2 != 0)
                                                e.CancelCommand();
                                            break;

                                        case EvenOddConstraint.OnlyOdd:

                                            if (number % 2 == 0)
                                                e.CancelCommand();
                                            break;
                                    }
                                }
                            }
                            else e.CancelCommand();
                            break;
                        }
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            var defaultValue = GetDefaultValue(textBox);

            var evenOddConstraint = GetEvenOddConstraint(textBox);

            switch (GetOnlyNumeric(textBox))
            {
                case NumericFormat.Double:
                    {
                        if (double.TryParse(textBox.Text, out double number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:

                                    if (number % 2 != 0)
                                        textBox.Text = defaultValue;
                                    break;

                                case EvenOddConstraint.OnlyOdd:

                                    if (number % 2 == 0)
                                        textBox.Text = defaultValue;
                                    break;
                            }
                        }
                        else textBox.Text = defaultValue;
                        break;
                    }
                case NumericFormat.Int:
                    {
                        if (int.TryParse(textBox.Text, out int number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:

                                    if (number % 2 != 0)
                                        textBox.Text = defaultValue;
                                    break;
                                case EvenOddConstraint.OnlyOdd:

                                    if (number % 2 == 0)
                                        textBox.Text = defaultValue;
                                    break;
                            }
                        }
                        else textBox.Text = defaultValue;
                        break;
                    }
                case NumericFormat.Uint:
                    {
                        if (uint.TryParse(textBox.Text, out uint number))
                        {
                            switch (evenOddConstraint)
                            {
                                case EvenOddConstraint.OnlyEven:

                                    if (number % 2 != 0)
                                        textBox.Text = defaultValue;
                                    break;
                                case EvenOddConstraint.OnlyOdd:

                                    if (number % 2 == 0)
                                        textBox.Text = defaultValue;
                                    break;
                            }
                        }
                        else textBox.Text = defaultValue;
                        break;
                    }
                case NumericFormat.Natural:
                    {
                        if (uint.TryParse(textBox.Text, out uint number))
                        {
                            if (number == 0) textBox.Text = defaultValue;
                            else
                            {
                                switch (evenOddConstraint)
                                {
                                    case EvenOddConstraint.OnlyEven:

                                        if (number % 2 != 0)
                                            textBox.Text = defaultValue;
                                        break;
                                    case EvenOddConstraint.OnlyOdd:

                                        if (number % 2 == 0)
                                            textBox.Text = defaultValue;
                                        break;
                                }
                            }
                        }
                        else textBox.Text = defaultValue;
                        break;
                    }
            }
        }
    }
}
