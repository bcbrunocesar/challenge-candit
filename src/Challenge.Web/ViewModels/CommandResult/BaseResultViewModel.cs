using System.Collections.Generic;

namespace Challenge.Web.ViewModels.CommandResult
{
    public abstract class BaseResultViewModel
    {
        public List<NotificationViewModel> Notifications { get; set; }
    }
}