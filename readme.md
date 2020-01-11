**The code is based on [Dapper-Extensions](https://github.com/tmsmith/Dapper-Extensions) and extends several methods.**

New Features
--------
* Supports asynchronous methods.
* Add `GetFirstOrDefault` method.
* Extended `Update` method to update specified fields.
* Extended `GetList` method support limit count.
* Set Environment Variable `ASPNETCORE_ENVIRONMENT` to `DEVELOPMENT` will print out the SQL.

# Installation

https://www.nuget.org/packages/Dapper.Extensions.Core/

```
PM> Install-Package Dapper.Extensions.Core
```

# Examples

The following examples will use a Person POCO defined as:

```c#
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Active { get; set; }
    public DateTime DateCreated { get; set; }
}
```


## GetFirstOrDefault

```c#
using (SqlConnection cn = new SqlConnection(_connectionString))
{
    cn.Open();
    IPredicate predicate = Predicates.Field<Person>(f => f.FirstName, Operator.Eq, "Foo");
    Person person = cn.GetFirstOrDefault<Person>(predicate);	
    cn.Close();
}
```

## Update 

```c#
using (SqlConnection cn = new SqlConnection(_connectionString))
{
    cn.Open();
    IPredicate predicate = Predicates.Field<Person>(f => f.FirstName, Operator.Eq, "Foo");
    cn.Update<Person>(new { FirstName = "Foo_a", LastName = "Bar_a" }, predicate);
    cn.Close();
}
```

## GetList

```c#
using (SqlConnection cn = new SqlConnection(_connectionString))
{
    cn.Open();
    var predicate = Predicates.Field<Person>(f => f.Active, Operator.Eq, true);
    IEnumerable<Person> list = cn.GetList<Person>(predicate, limitCount: 10);
    cn.Close();
}
```
