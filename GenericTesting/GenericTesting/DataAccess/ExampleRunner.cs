using GenericTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.DataAccess
{
    public static class ExampleRunner
    {
        public static IEnumerable<Group> GetGroupsFromUser(int userId)
        {
            using(var talker = new SQLTalker())
            {
                var tb = talker.GetData($"Select DISTINCT g.GroupId, g.GlobalGroupName FROM dbo.Mem_UserRoleGroup mu JOIN dbo.Mem_Group g ON g.GroupID = mu.GroupID AND mu.UserID = {userId}");
                return tb.ConvertTo<Group>();
            }
        }
    }
}
