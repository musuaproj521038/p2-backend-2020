﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.DTO
{
    public class ArticleFieldEditTemplateDTO
    {
        public int FieldID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
