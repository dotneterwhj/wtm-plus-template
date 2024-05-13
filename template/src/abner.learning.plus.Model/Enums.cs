using System;
using System.ComponentModel.DataAnnotations;

namespace Abner.Learning.Plus.Model
{

    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}