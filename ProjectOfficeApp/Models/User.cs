using System;
using System.Collections.Generic;

namespace ProjectOfficeApp.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;
}
