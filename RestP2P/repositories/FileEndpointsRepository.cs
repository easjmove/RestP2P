using RestP2P.models;

namespace RestP2P.repositories
{
    public class FileEndpointsRepository
    {
        private List<FileEndpoint> endpoints = new List<FileEndpoint>();

        public void Add(FileEndpoint newEndpoint)
        {
            endpoints.Add(newEndpoint);
        }

        public IEnumerable<FileEndpoint> GetByFilename(string fileName)
        {
            return endpoints.FindAll(x => x.Filename.ToLower() == fileName.ToLower());
        }
    }
}
