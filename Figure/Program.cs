using _4dots;
using Dots;

Figure square = new(new Dot(0, 0, 0), new Dot(0, 1, 0), new Dot(1, 1, 0), new Dot(1, 0, 0));
Figure rectangle = new(new Dot(0, 0, 0), new Dot(0, 2, 0), new Dot(1, 2, 0), new Dot(1, 0, 0));

Console.WriteLine(square.Structure());

Console.WriteLine(square.Coplanar());


