using Books.Core.Entities;
using System;
using System.Collections.Generic;
using Utils;

namespace Books.ImportConsole {
    public static class ImportController {
        private const string FILE_NAME = "books.csv";
        private const char SEPARATOR = '~';

        public static IEnumerable<Book> ReadBooksFromCsv()
        {
            string[][] matrix = MyFile.ReadStringMatrixFromCsv(FILE_NAME, false);
            IList<Book> books = new List<Book>();
            IList<BookAuthor> bookAuthors = new List<BookAuthor>();
            IDictionary<string, Author> authors = new Dictionary<string, Author>();

            foreach (var part in matrix)
            {
                Book book = new Book
                {
                    Title = part[1],
                    Publishers = part[2],
                    Isbn = part[3]
                };

                string[] names = part[0].Split(SEPARATOR);
                foreach (var name in names)
                {
                    Author author;
                    if (!authors.TryGetValue(name, out author))
                    {
                        author = new Author
                        {
                            Name = name
                        };
                        authors.Add(name, author);
                    }

                    BookAuthor bookAuthor = new BookAuthor
                    {
                        Author = author,
                        Book = book
                    };
                    book.BookAuthors.Add(bookAuthor);
                }
                books.Add(book);
            }

            return books;
        }
    }
}
