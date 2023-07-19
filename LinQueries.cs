using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{

    public class LinQueries
    {
            private List<Book> LibrosCollection = new List<Book>();

        public LinQueries(){
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.LibrosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true})!;
            }
        }

        public IEnumerable<Book> TodaLaColecion(){
            return LibrosCollection;
        }


        public IEnumerable<Book> LibrosDespuesDel2000(){

            //extension method
            //return LibrosCollection.Where(p=>p.PublishedDate.Year>2000);

            //query expresion
            return from l in LibrosCollection  where l.PublishedDate.Year> 2000 select l;
        }

        public IEnumerable<Book> LibrosPorCantidadDePaginasYTitulo(int cantPag, string titulo){

            //return LibrosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("Action"));
            return from l in LibrosCollection where l.PageCount>cantPag && l.Title.Contains(titulo) select l;
        }

        public bool AlMenosUnLibroEsDe2005(){
            return LibrosCollection.Any(p=> p.PublishedDate.Year == 2005);
        }
        public bool TodosLosLibrosTienenStatus(){
            return LibrosCollection.All(p=> p.Status != string.Empty);
        }

        public IEnumerable<Book> EsDeCategoria(String categoria){
            return  LibrosCollection.Where(p=> p.Categories.Contains(categoria));
        }


        public IEnumerable<Book> OrdenSegunCategoria(int ord, String categoria){
            IEnumerable<Book> coleccionOrdenada = LibrosCollection;

            if (ord ==1){
                coleccionOrdenada = EsDeCategoria(categoria).OrderBy(p=>p.Title);
            }else{
                coleccionOrdenada = EsDeCategoria(categoria).OrderByDescending(p=>p.Title);
            }
            return coleccionOrdenada;
        }

        public IEnumerable<Book> LibrosFiltradosOrdenados(IEnumerable<Book> listaFiltrada, int ord){
            if(ord ==1) {            
                return listaFiltrada.OrderBy(p=> p.PageCount);
            } else
            {
                return listaFiltrada.OrderByDescending(p=>p.PageCount);
            }
        }

        public IEnumerable<Book> GetCustomFilter(Func<Book,bool> filter) => this.LibrosCollection.Where(filter);
    

        public IEnumerable<Item> DevolverTituloYNumeroDePag(int cant){
            
            return LibrosCollection.Take(cant)
            .Select(p=> new Item() {Title = p.Title, PageCount = p.PageCount});

        }

        public IEnumerable<Book> LibrosConPaginasEntre(int min, int max){
            return LibrosCollection.Where(p=> p.PageCount >= min && p.PageCount <= max);
        }

        public DateTime FechaMinimaDePublicacion(){
            return LibrosCollection.Min(p=> p.PublishedDate);
        }

        public int MaxPaginas(){
            return LibrosCollection.Max(p=>p.PageCount);
        }

        public Book? LibroConMinPaginas(){
            return LibrosCollection.Where(p=>p.PageCount>0).MinBy(p=>p.PageCount);
        }

        public Book? LibroConFechaMasReciente(){
            return LibrosCollection.MaxBy(p=>p.PublishedDate);
        }

        public int PaginasTotalesDeLibrosConHasta500Pag(){
            return LibrosConPaginasEntre(0,500).Sum(p=>p.PageCount);
        }

        public String LibrosPosteriores2015(){
            return LibrosCollection
            .Where(p=> p.PublishedDate.Year> 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                if(TitulosLibros != string.Empty)
                    TitulosLibros += " - " + next.Title;
                else 
                    TitulosLibros +=  next.Title;

                return TitulosLibros;
            });
        }
        public double PromedioDeCaracteresDeTitulos(){
            return LibrosCollection.Average(p=> p.Title.Length);
        }

        public IEnumerable<IGrouping<int, Linq.Book>> LibrosAgrupadosPorAnio(){
            return LibrosCollection.Where(p=> p.PublishedDate.Year >= 2000).OrderBy(p=> p.PublishedDate.Year).GroupBy(p=> p.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorInicial(){
            return LibrosCollection.ToLookup(p=> p.Title[0], p=> p);
        }


        public IEnumerable<Book> LibrosDesdeEl2005Mas500Pag(){
            return GetCustomFilter(p=> p.PublishedDate.Year >2005).Join(GetCustomFilter(p=>p.PageCount>500), p=> p.Title, x=> x.Title, (p,x) => p);
        }

    }

        
    
    
}