using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Injection;

namespace Containers
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            ConfigureUnity(container);

            var dog = container.Resolve<IAnimal>();
            dog.walk();

            Console.ReadLine();
        }

        public static void ConfigureUnity(IUnityContainer container)
        {
            container.RegisterType<IAnimal>(new Unity.Lifetime.ContainerControlledLifetimeManager(), new InjectionFactory(c => new Dog()));
        }
    }


    public class Dog : IAnimal
    {
        public void walk()
        {
            Console.WriteLine("A walking Dog");
        }
    }

    public interface IAnimal
    {
        void walk();
    }

}


