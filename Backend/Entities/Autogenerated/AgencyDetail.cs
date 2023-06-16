using System;
using System.Collections.Generic;

namespace Backend;

public partial class AgencyDetail
{
    public int AgencyDetailsId { get; set; }

    public int AgencyCompanyUniqueNumber { get; set; }

    public string? AgencySite { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
