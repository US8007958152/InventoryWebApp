﻿using System;
using System.Collections.Generic;

namespace InventoryWebApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
