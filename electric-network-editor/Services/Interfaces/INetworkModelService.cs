using electric_network_editor.Models;
using System.Collections.Generic;

namespace electric_network_editor.Services.Interfaces
{
    public interface INetworkModelService
    {
        NetworkModel GetActiveNetworkModel();
        List<NetworkModel> GetAllNetworkModels();
        void LoadNetworkModel(string filePath);
    }
}