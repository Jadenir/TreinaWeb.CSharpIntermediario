using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "TreinaWeb"
            };
            Animal animal = new Animal
            {
                Id = 1,
                Especie = "Cachorro"
            };
            //RepositorioPessoa  repositorioPessoa = new RepositorioPessoa();
            //RepositorioAnimal repositorioAnimal = new RepositorioAnimal();
            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> repositorioAnimal = new RepositorioGenerico<Animal>();

            repositorioPessoa.Insert(pessoa);
            repositorioAnimal.Insert(animal);

            foreach (Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("Nome da pessoa :{0} ", p.Nome);
            }
            foreach (Animal a in repositorioAnimal.Get())
            {
                Console.WriteLine("Espécie do animal :{0} ", a.Especie);
            }
            string var1 = "Mundo!";

            Console.ReadKey();
        }

    }

}
