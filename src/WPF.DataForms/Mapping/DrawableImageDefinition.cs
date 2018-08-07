using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF.DataForms.Mapping
{
    public class DrawableImageDefinition : PropertyDefinition
    {
        public DrawableImageDefinition(String displayName, String imageSource, String selectedLine, bool drawable, String simpleLines, String selectedColor)
            : base(displayName)
        {
            ImageSource = imageSource;
            Drawable = drawable;
            SimpleLines = simpleLines;
            SelectedLine = selectedLine;
            SelectedColor = selectedColor;
        }

        /// <summary>
        /// ImageSource
        /// </summary>
        public String ImageSource { get; private set; }

        /// <summary>
        /// ImageSourceOriginal
        /// </summary>
        public String SimpleLines { get; private set; }

        /// <summary>
        /// SelectedLine
        /// </summary>
        public String SelectedLine { get; private set; }

        /// <summary>
        /// SelectedColor
        /// </summary>
        public String SelectedColor { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Drawable { get; private set; }

        /// <summary>
        /// CanDragDrop
        /// </summary>
        public bool CanDragDrop { get; private set; }

        public override FrameworkElementFactory CreateFactoryElement(bool isReadOnly, string stringFormat)
        {
            //if (isReadOnly)
            //{
            //    FrameworkElementFactory element;

            //    element = new FrameworkElementFactory(typeof(SimpleImageControl));
            //    element.SetBinding(SimpleImageControl.SourceProperty, new Binding(ImageSource));

            //    return element;
            //}
            //else
            //{
                FrameworkElementFactory element = new FrameworkElementFactory(typeof(DrawableImageControl));
                element.SetBinding(DrawableImageControl.SelectedColorProperty, new Binding(SelectedColor));
                element.SetBinding(DrawableImageControl.SourceProperty, new Binding(ImageSource) { Mode = BindingMode.TwoWay });

                if (SimpleLines != null)
                {
                    element.SetBinding(DrawableImageControl.LinesProperty, new Binding(SimpleLines));
                    element.SetBinding(DrawableImageControl.SelectedLineProperty, new Binding(SelectedLine) { Mode = BindingMode.TwoWay });
                }

                return element;
            //}
        }
    }
}
