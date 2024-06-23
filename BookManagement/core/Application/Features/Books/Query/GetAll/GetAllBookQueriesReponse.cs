﻿using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Query.GetAll
{
    public class GetAllBookQueriesReponse
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string filePDF { get; set; }
        public int AuthorId { get; set; }
        public AuthorDtos AuthorDtos { get; set; }
    }
}
