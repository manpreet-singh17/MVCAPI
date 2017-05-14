﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwebAPI.Models
{
    public class Product
    {
        public int ID { get; set; }

        //simple Required data annotation .
        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

    }
}
