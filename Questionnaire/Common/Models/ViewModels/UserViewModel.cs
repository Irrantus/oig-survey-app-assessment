using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public int QuestionnairesCount { get; set; }
    }
}
