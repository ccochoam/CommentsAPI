﻿using System;
using System.Collections.Generic;

namespace PraxedesAPI.Data.Models;

public partial class Post
{
    public long? UserId { get; set; }

    public long? Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }
}
