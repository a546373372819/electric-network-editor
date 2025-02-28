using electric_network_editor.Model;
using PluginContracts;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace electric_network_editor.ViewModels
{
    public class MainViewModel:BindableBase
    {
        public Dictionary<SymbolType, string> SymbolImagePaths { get; } = new()
        {
            { SymbolType.Source, "Images/triangle.png" },
            { SymbolType.Switch, "Images/rectangle.png" },
            { SymbolType.Node, "Images/circle.png" },
        };

        private readonly List<Symbol> _drawnSymbols = new();
        private readonly Dictionary<UIElement, Symbol> _uiElementToSymbolMap = new();
        
        public void RegisterSymbol(UIElement element, Symbol symbol)
        {
            _drawnSymbols.Add(symbol);
            _uiElementToSymbolMap[element] = symbol;
        }

        public Symbol GetSymbol(UIElement element) => _uiElementToSymbolMap[element];
        public bool HasSymbol(UIElement element) => _uiElementToSymbolMap.ContainsKey(element);
    }
}
