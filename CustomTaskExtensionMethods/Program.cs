// See https://aka.ms/new-console-template for more information



var a = new Test(1, "a")
{
    NameTwo = "b"
};

a.NameTwo = 2;

record Test(int Id, string Name)
{
    public int NameTwo { get; set; }
};