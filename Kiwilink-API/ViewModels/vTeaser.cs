using MongoDB.Bson;

namespace Kiwilink.ViewModels
{
    public class vTeaser
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Course { get; set; }
        public string Institute { get; set; }
        public bool Loading { get; set; }
    }
}
