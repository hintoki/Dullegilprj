using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dulaegil
{
    public class StackPanel : Grid
    {
        private readonly List<string> _tags = new List<string>
        {
            "Python", "PHP", "Java", "Pascal", "C#", "Scala", "C++", "Objective C", "Swift"
        };

        private const double MarginsHeight = 4;
        private readonly StackLayout _childStack;
        private readonly StackLayout _parentStack;
        private double _heightChildstack;
        private const double heightParentstack = 320;

        public StackPanel()
        {
            var entry = new Entry
            {
                Text = ""
            };

            //var button = new Button
            //{
            //    Text = "",
            //    BackgroundColor = Color.DarkGreen,
            //    TextColor = Color.White
            //};

            //button.Clicked += async (sender, args) =>
            //{
            //    var tag = entry.Text;
            //    await AddTagAsync(tag);
            //};

            _childStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 4,
            };

            _parentStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 0,
                Spacing = 4,
                Children = {_childStack },                
            };

            var grid = new Grid
            {
                Children = {_parentStack},
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center                
                
            };
            Children.Add(grid);

            
        }    

        protected async void CreateStackPanelAsync()
        {
            foreach(var tag in _tags)
            {
                await AddTagAsync(tag);
            }
        }

        public double AddButton(string str, double width)
        {
            var button = new Button
            {
                Text = str,
                TextColor = Color.White,
                BackgroundColor = Color.BlueViolet,
                BorderRadius = 5,
                BorderWidth = width
            };

            button.Clicked += (sender, args) =>
            {
                foreach (var child in _parentStack.Children)
                {
                    var stack = child as StackLayout;
                    if (stack != null && stack.Children.Contains(button))
                    {
                        stack.Children.Remove(button);
                    }
                }
            };

            _childStack.Children.Add(button);

            _heightChildstack += button.Height;

            return _heightChildstack;
        }

        public async Task AddTagAsync(string tag)
        {
            var button = new Button
            {
                Text = "#" + tag,
                TextColor = Color.White,
                BackgroundColor = Color.BlueViolet,
                BorderRadius = 5,
            };

            button.Clicked += (sender, args) =>
            {
                foreach (var child in _parentStack.Children)
                {
                    var stack = child as StackLayout;
                    if (stack != null && stack.Children.Contains(button))
                    {
                        stack.Children.Remove(button);
                    }
                }
            };

            _childStack.Children.Add(button);

            await Task.Delay(950);

            _heightChildstack += button.Width;

            if (heightParentstack <= _heightChildstack)
            {
                _childStack.Children.Remove(button);
                _parentStack.Children.Add(CopyOfStackLayout());
                _childStack.Children.Clear();

                _childStack.Children.Add(button);
                _heightChildstack = button.Width + MarginsHeight;
            }
        }

        private View CopyOfStackLayout()
        {
            var copystackLayout = new StackLayout
            {
                Orientation = _childStack.Orientation,
                HorizontalOptions = _childStack.HorizontalOptions,
                Spacing = _childStack.Spacing
            };

            var children = _childStack.Children.ToList();

            foreach(var stackLayoutChild in children)
            {
                _childStack.Children.Remove(stackLayoutChild);
                copystackLayout.Children.Add(stackLayoutChild);
            }

            return copystackLayout;
        }
    }


}
