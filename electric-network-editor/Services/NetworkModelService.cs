using electric_network_editor.Models;
using electric_network_editor.Services.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Services
{
    public class NetworkModelService : INetworkModelService
    {
        private static readonly NetworkModelService _networkModelService = new NetworkModelService();
        public static NetworkModelService Instance => _networkModelService;

        private List<NetworkModel> _networkModels;
        private NetworkModel _activeNetworkModel;

        public NetworkModelService()
        {
            _networkModels = new List<NetworkModel>();
        }

        public void LoadNetworkModel(string filePath)
        {
            // Logic to load the network model from a file and add it to the list
            var networkModel = new NetworkModel(); // Populate this with actual data from the file
            _networkModels.Add(networkModel);
        }

        public void SetActiveNetworkModel(string modelName)
        {
        }

        public NetworkModel GetActiveNetworkModel()
        {
            return _activeNetworkModel;
        }

        public List<NetworkModel> GetAllNetworkModels()
        {
            return _networkModels;
        }
    }
}
