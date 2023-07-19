using Linq;

LinQueries queries = new LinQueries();

//Toda la coleccion
//ImprimirValores(queries.TodaLaColecion());


//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

//+250 pag de Action
//ImprimirValores(queries.LibrosPorCantidadDePaginasYTitulo(250, Action));

//libros publicados en 2005
//Console.WriteLine(queries.AlMenosUnLibroEsDe2005());

//libros de python
//ImprimirValores(queries.EsDeCategoria("Python"));

//Libros de java ordenados de forma asc y desc por nombre
//ImprimirValores(queries.OrdenSegunCategoria(1,"Java"));
//ImprimirValores(queries.OrdenSegunCategoria(0,"Java"));


//Libros con mas de 450 paginas ordenados asc y desc
//ImprimirValores(queries.LibrosFiltradosOrdenados(queries.TodaLaColecion().Where(p=> p.PageCount>450), 1));
//Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
//ImprimirValores(queries.LibrosFiltradosOrdenados(queries.TodaLaColecion().Where(p=> p.PageCount>450), 0));

//Tomar los primeros 3 libros con fecha de publicación mas reciente que sean de java 
//ImprimirValores(queries.LibrosFiltradosOrdenados(queries.EsDeCategoria("Java"),1).OrderBy(p=> p.PublishedDate).TakeLast(3));

//3er y 4to libro con más de 400 paginas
//ImprimirValores(queries.TodaLaColecion().Where(p=> p.PageCount >400).Take(4).Skip(2));

//Imprimir 3 primeros libros 
//ImprimirItems(queries.DevolverTituloYNumeroDePag(3));

//Cantidad de registros (libros) entre 200 y 500 paginas
//IEnumerable<Book> books = queries.LibrosConPaginasEntre(200,500);
//Console.WriteLine(books.Count());

//Fecha minima de publicación
//Console.WriteLine(queries.FechaMinimaDePublicacion());

//Fecha minima de publicación
//Console.WriteLine($"Mayor cantidad de paginas {queries.MaxPaginas()}");

//libro con menor cantidad de paginas
//Book libroMenorPag = queries.LibroConMinPaginas();
//Console.WriteLine($"Libro con menos paginas; {libroMenorPag.Title} - {libroMenorPag.PageCount}");

//Libro con fecha de publicación más reciente. 
//Book libroMasReciente = queries.LibroConFechaMasReciente();
//Console.WriteLine($"Libro con fecha de publicación más reciente; {libroMasReciente.Title} - {libroMasReciente.PublishedDate}");

//Suma de las paginas de los libros con hasta 500 paginas
//Console.WriteLine($"La suma de todas las paginas de los libros con hasta 500 es : {queries.PaginasTotalesDeLibrosConHasta500Pag()}");

//Libros publicados despues del 2015
//Console.WriteLine($"Libros publicados despues del 2015 : {queries.LibrosPosteriores2015()}");

//Promedio de caracteres de los titulos de la coleccion 
//Console.WriteLine($"Promedio de caracteres de los titulos de la coleccion : {queries.PromedioDeCaracteresDeTitulos()}");

//Libros publicados despues del 2000 agrupados por año
//ImprimirGrupo(queries.LibrosAgrupadosPorAnio());

//Diccionario Agrupado por primera letra de titulo
//printDictionary(queries.DiccionarioDeLibrosPorInicial(),'a');

//Libros publicados posterior al 2005 con +500 paginas

ImprimirValores(queries.LibrosDesdeEl2005Mas500Pag());



void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    } 
    else 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}
void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> listaDeLibros)
{
    foreach(var grupo in listaDeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}
void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0,-60} {1,9} {2,11}\n", "Title", "Numero de Paginas", "Fecha publicación");
    foreach (var item in listaDeLibros)
    {
        Console.WriteLine("{0,-70} {1,13} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
void ImprimirItems(IEnumerable<Item> listaDeItems)
{
    Console.WriteLine("{0,-60} {1,9} {2,11}\n", "Title", "Numero de Paginas");
    if (listaDeItems != null)
        foreach (var item in listaDeItems)
        {
            Console.WriteLine("{0,-70} {1,13} {2,15}", item.Title, item.PageCount);
        }
}
void ImprimirLibro(Book libro)
{
    Console.WriteLine("{0,-60} {1,9} {2,11}\n", "Title", "Numero de Paginas");
    Console.WriteLine("{0,-70} {1,13} {2,15}", libro.Title, libro.PageCount);
}
