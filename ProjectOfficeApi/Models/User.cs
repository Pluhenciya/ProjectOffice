using System;
using System.Collections.Generic;

namespace ProjectOfficeApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;
}
