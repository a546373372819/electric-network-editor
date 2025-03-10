using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Events
{
    public static class EventAggregatorProvider
    {
        private static readonly IEventAggregator _eventAggregator = new EventAggregator();

        public static IEventAggregator Instance => _eventAggregator;
    }
}
