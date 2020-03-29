using System;

namespace ApiSep.Library.Interfaces
{
    public interface ISender
    {
        int LocalIdUser { get; set; }
        string LocalUsername { get; set; }
        string LocalPassword { get; set; }
        string UserEmailAddress { get; set; }
        string UserMailPassword { get; set; }
        int? IdWorkingAs { get; set; }
        string WorkingAsUsername { get; set; }
        int LocalIdDealer { get; set; }
        string LocalDealerName { get; set; }
        DateTime RequestDateTime { set; }

    }
}
