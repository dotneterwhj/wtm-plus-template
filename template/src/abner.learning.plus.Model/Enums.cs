using System;
using System.ComponentModel.DataAnnotations;

namespace abner.learning.plus.Model
{

    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}