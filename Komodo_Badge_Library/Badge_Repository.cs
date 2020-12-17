using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge_Library
{

    public class BadgeRepo
    {
        public List<string> _doorNames = new List<string>();
        public Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();
        public Badge badge = new Badge();
        
        


        //create
        public void AddBadge(Badge badge)
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        //read
        public Dictionary<int, List<string>> GetDictionary()
        {
            return _doorAccess;
        }

        //update
        public void GiveAccess(int badgeID, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeID];
            doors.Add(doorAccess);
        }

        //delete
        public void RemoveAccess(int badgeID, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeID];
            doors.Remove(doorAccess);
        }             

        

    }
}
