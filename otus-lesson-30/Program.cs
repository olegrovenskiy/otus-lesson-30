// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.ComponentModel;

Console.WriteLine("Hello, World!");




// Тестирование

Plant plant1 = new Plant(77, "tree");

var plant2 = plant1.MyClone();

plant2.Type = "vegetable";

Console.WriteLine(plant1.Type+plant1.Id); // tree77 - ok
Console.WriteLine(plant2.Type+plant2.Id); // vegetable77 - ok 


Tree tree1 = new Tree (33, "tree");
tree1.Name = "apple";
var tree2 = tree1.MyClone();
tree2.Name = "pine";

Console.WriteLine(tree1.Name+tree1.Id+tree1.Type); // apple33tree - ok
Console.WriteLine(tree2.Name + tree2.Id + tree2.Type); // pine33tree - ok 


RedApple DarkRedapple = new RedApple(55, "tree", "DarkApple");

DarkRedapple.Color = "VeryRed";
Console.WriteLine (DarkRedapple.Name + DarkRedapple.Id + DarkRedapple.Type+DarkRedapple.Color); // DarkApple55treeVeryRed - ok


var WhiteReadApple = DarkRedapple.MyClone();
Console.WriteLine(WhiteReadApple.Name + WhiteReadApple.Id + WhiteReadApple.Type + WhiteReadApple.Color); // DarkApple55tree - ok



// в тестировании мы убеждаемся что клон имеет те же значения свойств что и оригинал и при изменении в клоне свойста, оно не меняется в оригинале
// И клонируются только те свойства что прописаны в конструкторе класса

// тест реализации интерфейса IClonable

var TestIClon = (RedApple)DarkRedapple.Clone();
TestIClon.Name = "Test";
Console.WriteLine(TestIClon.Name + TestIClon.Id + WhiteReadApple.Type + WhiteReadApple.Color); // Test55tree - ok
Console.WriteLine(WhiteReadApple.Name + WhiteReadApple.Id + WhiteReadApple.Type + WhiteReadApple.Color); // DarkApple55tree - ok



Console.ReadKey();





// Классы и их описание 

// 1-ый уровень, класс Растение, у него есть свойство Идентификатор, и тип. Он также реализует generic интерфейс для клонирования класса растений 
public class Plant : IMyCloneable<Plant>

{

    public int Id { get; set; }
    public string Type { get; set; }

    public Plant (int id, string type)
    {
        Id = id;
        Type = type;
    }


    public Plant  MyClone ()
    {
   
        Plant plant = new Plant (Id, Type);
        return plant;
    }


}



// Второй уровень
// Класс дерево, наследует от родительского класса Растения - Идентификатор и категорию и добавляет тип. И также реализует метод myclone для клонирования класса деревьев
class Tree : Plant, ICloneable

{
    public string Name { get; set; }
    public Tree(int id, string type) : base(id, type) {}

    public Tree MyClone()
    {

        Tree tree= new Tree (Id, Type);
        return tree;
    }

    public object Clone() { return this.MyClone(); }
}







// 3-й Уровень, Класс Крассное Яблоко, наследует от родительского класса Дерево. наследует Идентификатор и Тип, и реализует клонирования себя.
class RedApple : Tree, ICloneable

{
    
    public string Color { get; set; }
    public RedApple(int id, string type, string name) : base(id,type)
    {
        Name = name;
    }

    public RedApple MyClone()
    {

        RedApple redApple = new RedApple(Id, Type, Name);
        return redApple;
    }

    public object Clone() {return this.MyClone(); }

}



public interface IMyCloneable<T> where T : class
{
    public T MyClone();


}