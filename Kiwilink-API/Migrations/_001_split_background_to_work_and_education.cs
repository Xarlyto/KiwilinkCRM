using Kiwilink.Models;
using MongoDB.Entities;

namespace Kiwilink.Migrations
{
    public class _001_split_background_to_work_and_education : IMigration
    {
        public void Upgrade()
        {
            DB.Update<Client>()
              .Match(f => f.Empty)
              .Modify(b => b.Rename("Background", "Education"))
              .Modify(b => b.Set("Work", ""))
              .Execute();
        }
    }
}
