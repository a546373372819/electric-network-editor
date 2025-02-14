using electric_network_editor.Model;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace electric_network_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RadioButton _selectedSymbolBtn;
        private UIElement _selectedSymbol;
        private List<Symbol> _drawnSymbols=new List<Symbol>();


        Dictionary<UIElement, Symbol> _UIElementToSymbolMap = new Dictionary<UIElement, Symbol>();

        Dictionary<SymbolType, string> _symbolImgSrcMap= new Dictionary<SymbolType, string>

        { 
            { SymbolType.Source,"Images/triangle.png" },
            { SymbolType.Switch,"Images/rectangle.png" },
            { SymbolType.Node,"Images/circle.png" },
        };

        public MainWindow()
        {
            InitializeComponent();

            CreateSymbolButtons();

        }


        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                _selectedSymbolBtn = button;
            }
        }


        private void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("AAA");
            if ((bool)NetworkConnectBtn.IsChecked)
            {
                
                if(_selectedSymbol != null) 
                {

                    DrawLine(_selectedSymbol, (UIElement)sender);
                    RemoveHighlight(_selectedSymbol);
                    _selectedSymbol = null;
                    return;
                }

                _selectedSymbol = (UIElement)sender;
                ApplyHighlight(_selectedSymbol);

            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedSymbolBtn != null)
            {
                Point clickPosition = e.GetPosition(NetworkCanvas);

                DrawSymbol(clickPosition);

            }
        }

        private void ConnectionBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveHighlight(_selectedSymbol);
            _selectedSymbol = null;
        }

        private void DrawLine(UIElement parent,UIElement child)
        {

            double x1 = _UIElementToSymbolMap[parent].position.X + 50;
            double y1= _UIElementToSymbolMap[parent].position.Y + 50;

            double x2= _UIElementToSymbolMap[child].position.X + 50;
            double y2= _UIElementToSymbolMap[child].position.Y + 50;

            if(Math.Abs(x2 - x1)>50 & Math.Abs(y2 - y1)>50)
            {
                if (x2>x1)
                {
                    x2 -= 55;
                }
                else
                {
                    x2 += 55;
                }

                if (y2 > y1)
                {
                    y1 += 55;
                }
                else
                {
                    y1 -= 55;
                }

                Line connectionLineVert = new()
                {
                    X1 = x1,
                    Y1 = y1,

                    X2 = x1,
                    Y2 = y2,

                    Stroke = Brushes.Black,
                    StrokeThickness = 5
                };

                Line connectionLineHor = new()
                {
                    X1 = x1,
                    Y1 = y2,

                    X2 = x2,
                    Y2 = y2,

                    Stroke = Brushes.Black,
                    StrokeThickness = 5
                };

                NetworkCanvas.Children.Add(connectionLineHor);
                NetworkCanvas.Children.Add(connectionLineVert);

                return;
            }

            if (Math.Abs(x2 - x1) > 50)
            {
                if (x2 > x1)
                {
                    x2 -= 55;
                    x1 += 55;
                }
                else
                {
                    x2 += 55;
                    x1 -= 55;
                }
                y2 = y1;

            }
            else
            {
                if (y2 > y1)
                {
                    y2 -= 55;
                    y1 += 55;
                }
                else
                {
                    y2 += 55;
                    y1 -= 55;
                }
                x2 = x1;
            }


            Line connectionLine = new()
            {
                X1 = x1,
                Y1 = y1,

                X2 = x2,
                Y2 = y2,

                Stroke = Brushes.Black,
                StrokeThickness = 5
            };

            NetworkCanvas.Children.Add(connectionLine);
        }

        private void DrawSymbol(Point position)
        {
           
            SymbolType drawnSymbolType = (SymbolType)_selectedSymbolBtn.Tag;

            Image symbolImage = new Image
            {
                Source = new BitmapImage(new System.Uri(_symbolImgSrcMap[drawnSymbolType], System.UriKind.Relative)),
                Width = 100,
                Height = 100
            };
            symbolImage.MouseDown += SymbolIcon_MouseDown;

            position.X -= 50;
            position.Y -= 50;
            Canvas.SetLeft(symbolImage, position.X);
            Canvas.SetTop(symbolImage, position.Y);

            Symbol drawnSymbol = new Symbol(drawnSymbolType,new List<Symbol>(),position);

            _drawnSymbols.Add(drawnSymbol);
            _UIElementToSymbolMap.Add(symbolImage, drawnSymbol);

            NetworkCanvas.Children.Add(symbolImage);
            
            _selectedSymbolBtn.IsChecked = false;
            _selectedSymbolBtn = null;
        }

        private void CreateSymbolButtons()
        {
            foreach (SymbolType obj in Enum.GetValues(typeof(SymbolType)))
            {
                RadioButton rb = new RadioButton();
                rb.Click += new RoutedEventHandler(SymbolButton_Click);
                rb.Tag= obj;

                Image symbolImage = new Image
                {
                    Source = new BitmapImage(new System.Uri(_symbolImgSrcMap[obj], System.UriKind.Relative)),
                };

                rb.Content = symbolImage;

                Sidebar.Children.Add(rb);

            }
        }

        private void ApplyHighlight(UIElement element)
        {
            if (element is Image img)
            {
                img.Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = Colors.Yellow,
                    BlurRadius = 10,
                    ShadowDepth = 0
                };
            }
        }

        private void RemoveHighlight(UIElement element)
        {
            if (element is Image img)
            {
                img.Effect = null; // Remove glow effect
            }
        }

    }
}
