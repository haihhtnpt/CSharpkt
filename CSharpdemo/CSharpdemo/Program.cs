// See https://aka.ms/new-console-template for more information
using CSprj;
using CSprj.Service;
using CSprj.Service.Validation;


IValidator service = new Validator();

Ticket a = new Ticket();
a.InputData();
Console.WriteLine("");
var validationResult = service.Validate(a);

if (validationResult.Errors.Any() == true)
{
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine(error.Key + ": ");
        error.Value.ToList().ForEach(x => Console.WriteLine(" " + x));

    }
    if (a.Type == TicketType.Error)
    {
        Console.WriteLine("TicketType:");
        Console.WriteLine(" TicketType field is not valid.(Only 0 or 1).");

    }
    Console.WriteLine("Dữ liệu được lưu không thành công. Yêu cầu nhập lại!");
}
else
{
    a.OutputData();
}

