using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOverview.Models;

namespace WpfOverview.Patterns
{
    class UserAddingMediator
    {
        public static readonly UserAddingMediator Default = new UserAddingMediator();
        public Action<User> addUserAction;
        public void Send(User user)
        {
            addUserAction?.Invoke(user);
        }
        public void Register(Action<User> addUserAction)
        {
            this.addUserAction = addUserAction;
        }
    }
}
