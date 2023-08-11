using System;
using System.Collections.Generic;
using System.IO;

namespace TP01
{
    internal class BookCSV
    {
        private static readonly string nomeArquivoCSV = "D:\\IFSP\\3 ano\\2 semestre\\SWII6\\books.csv";

        private Library library;
        private AutorCSV autor = new AutorCSV();

        public BookCSV()
        {
            var books = new List<Book>();
            using (var file = File.OpenText(BookCSV.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textoLivro = file.ReadLine();
                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }
                    var infoLivro = textoLivro.Split(',');

                    if (infoLivro.Length >= 3)
                    {
                        var name = infoLivro[0];
                        var author = infoLivro[1];
                        double price = Convert.ToDouble(infoLivro[2]);

                        if (infoLivro.Length >= 4 && !string.IsNullOrEmpty(infoLivro[3]))
                        {
                            int qty = Convert.ToInt32(infoLivro[3]);
                            var autoresRet = autor.retornaAuthor(author);
                            books.Add(new Book(name, autoresRet, price, qty));
                        }
                        else
                        {
                            var autoresRet = autor.retornaAuthor(author);
                            books.Add(new Book(name, autoresRet, price));
                        }
                    }
                    else
                    {
                        // Lidar com registros incompletos ou inválidos
                    }
                }
            }
            library = new Library(books);
        }

        public Library Library => library;
    }
}
