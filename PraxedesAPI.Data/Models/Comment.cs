﻿using System;
using System.Collections.Generic;

namespace PraxedesAPI.Data.Models;

public partial class Comment
{
    public long? PostId { get; set; }

    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Body { get; set; }
}
