namespace ProgramClass {

    public class Person
{
  private string name; // field
  public string Name   // property
  {
    get { return name; }
    set { name = value; }
  }
}

public class Program
{
  public static void Main(string[] args)
  {

    Person myObj = new Person();
    foreach(string name in args){
        myObj.Name = name;
    }
    Console.WriteLine(myObj.Name);
  }
}

}

