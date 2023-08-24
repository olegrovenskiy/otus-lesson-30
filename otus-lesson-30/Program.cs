// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

Console.WriteLine("Hello, World!");







// Тестирование

Plant plant1 = new Plant(77, "tree");

var plant2 = plant1.Clone();

plant2.Type = "vegetable";

Console.WriteLine(plant1.Type); // tree - ok
Console.WriteLine(plant2.Type); // vegetable - ok 


Tree tree1 = new Tree (33, "tree");
tree1.Name = "apple";
var tree2 = tree1.Clone();
tree2.Name = "pine";

Console.WriteLine(tree1.Name); // apple - ok
Console.WriteLine(tree2.Name); // pine - ok 


Console.ReadKey();







// 1-ый уровень, класс Растение, у него есть свойство Идентификатор, и тип. Он также реализует generic интерфейс для клонирования растений 
public class Plant : IMyCloneable<Plant>

{

    public int Id { get; set; }
    public string Type { get; set; }

    public Plant (int id, string type)
    {
        Id = id;
        Type = type;
    }


    public Plant  Clone ()
    {
   
        return MemberwiseClone() as Plant;
    }


}



// Второй уровень
// Класс дерево, наследует от родительского класса Растения - Идентификатор и категорию и добавляет тип. И также реализует метод clone для клонирования деревьев
class Tree : Plant

{
    public string Name { get; set; }
    public Tree(int id, string type) : base(id, type) {}

    public Tree Clone()
    {

        return MemberwiseClone() as Tree;
    }

}





/*

// Класс куст, наследует от родительского класса Идентификатор и категорию и добавляет тип
class Bush : Plant

{
    public string Type { get; set; }
    public Bush(int id, string category, string type) : base(id, category)
    {
        Type = type;
    }

}

// Класс корнеплод, наследует от родительского класса Идентификатор и категорию и добавляет тип
class Root : Plant

{
    public string Type { get; set; }
    public Root(int id, string category, string type) : base(id, category)
    {
        Type = type;
    }

}

// Третий уровень

// класс яблочное дерево, наследуется от дерева

class Apple : Tree

{
    public string Name { get; set; }
    public Apple(int id, string category, string type) : base (id, category, type)  { }


}


// класс Редис наследуется от корнеплода

class Redis : Root

{
    public string Name { get; set; }
    public Redis(int id, string category, string type) : base(id, category, type) { }

}

*/

public interface IMyCloneable<T> where T : class
{
    public T Clone();


}