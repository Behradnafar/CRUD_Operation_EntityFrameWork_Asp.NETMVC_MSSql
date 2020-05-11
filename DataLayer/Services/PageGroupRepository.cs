using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContext db;               //Because we should write a query
        public PageGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;
        }
        public PageGroup GetGroupById(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }
        public void InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
            }
            catch (Exception)
            {
              
            }
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;    // At first find in DB by state find the primarykey and after that modified the field
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            
            db.Dispose();
        }

        public IEnumerable<ShowGroupsViewModel> GetGroupsForView()
        {
            return db.PageGroups.Select(g => new ShowGroupsViewModel()
            {
                GroupId =g.GroupId ,
                GroupTitle = g.GroupTitle ,
                PageCount= g.Pages.Count
            });
        }
    }
}
