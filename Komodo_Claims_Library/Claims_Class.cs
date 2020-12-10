using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Library
{
    public enum ClaimType
    {
        Car = 1,
        Home = 2,
        Theft = 3,
        Boat = 4,
    }
    public class Claims
    {
        public int ClaimID { get; set; }
        public DateTime DateOfClaim { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIncident { get; set; }
        public double ClaimAmount { get; set; }
        public bool IsValid { get; set; }
        public ClaimType ClaimType { get; set; }

        public Claims() { }

        public Claims(int claimID, DateTime dateOfClaim, string description, DateTime dateOfIncident, double claimAmount, bool isValid, ClaimType claimType)
        {
            ClaimID = claimID;
            DateOfClaim = dateOfClaim;
            Description = description;
            DateOfIncident = dateOfIncident;
            ClaimAmount = claimAmount;
            IsValid = isValid;
            ClaimType = claimType;
        }
    }
}
