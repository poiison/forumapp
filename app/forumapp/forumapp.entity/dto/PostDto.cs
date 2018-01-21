﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.entity.dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public UserDto User { get; set; }
    }
}