// See https://aka.ms/new-console-template for more information
using CSprj;
using CSprj.Service;
using CSprj.Service.Validation;


IValidator service = new Validator();

Ticket a = new Ticket();
a.InputData();
a.OutputData();
var validationResult = service.Validate(a);

foreach (var error in validationResult.Errors)
{
    Console.WriteLine(error.Key + ": ");
    error.Value.ToList().ForEach(x => Console.WriteLine(" " + x));
}
//Console.WriteLine($"ten la{a.Name}");