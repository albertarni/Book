﻿namespace BiblioNet.Core.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfCharacters { get; set; }
    }
}
