using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Library
{
    class ClaimsRepository
    {
        private List<Claims> _claimsInfo = new List<Claims>();
        //create
        public void AddItemsToMenu(Claims content)
        {
            _claimsInfo.Add(content);
        }
        //read
        public List<Claims> GetMenu()
        {
            return _claimsInfo;
        }

        public void PrintMenu()
        {
            foreach (Claims content in _claimsInfo)
            {
                Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount:$ {content.ClaimAmount}\n" +
                    $"Date of Accident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim} 
            }
        }
        //update
        public bool UpdateExistingMenu(int originalItem, Claims newContent)
        {
            Claims oldContent = GetClaimByNumber(originalItem);

            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.Description = newContent.Description;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.IsValid = newContent.IsValid;
                oldContent.ClaimType = newContent.ClaimType;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveItemsFromMenu(int claimID)
        {
            Claims content = GetClaimByNumber(claimID);

            if (content == null)
            {
                return false;
            }
            int initialCount = _claimsInfo.Count;
            _claimsInfo.Remove(content);

            if (initialCount > _claimsInfo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Claims GetClaimByNumber(int claimID)
        {
            foreach (Claims content in _claimsInfo)
            {
                if (content.ClaimID == claimID)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
