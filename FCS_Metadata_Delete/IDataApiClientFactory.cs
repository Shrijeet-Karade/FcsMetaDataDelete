using System.Threading.Tasks;
using Tavisca.DataApis.Sdk.Interfaces;

namespace FCS_Metadata_Delete
{
    public interface IDataApiClientFactory
    {
        IDataAPIClient GetClientAsync();
    }
}