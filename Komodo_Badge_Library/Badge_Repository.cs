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
        public bool GiveAccess(int badgeID, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeID];
            int previousCount = doors.Count;
            doors.Add(doorAccess);
            int afterCount = doors.Count;
            if (afterCount > previousCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveAccess(int badgeID, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeID];
            int previousCount = doors.Count;
            doors.Remove(doorAccess);
            int afterCount = doors.Count;
            if (afterCount < previousCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public KeyValuePair<int, List<string>> GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>>badge in _doorAccess)
            {
                if (badge.Key == badgeID)
                {
                    return badge;
                }
            }
            return default;
        }


    }
}
