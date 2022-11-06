
using System.Text;
using System.Runtime.CompilerServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSprj
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public Ticket(DateTime birth, TicketType type)
        {
            _birth = birth;
            Type = type;
        }
        public Ticket(string name, string address, string cardNo, DateTime birth, TicketType type, string emailAddress)
        {
            Name = name;
            Address = address;
            CardNo = cardNo;
            _birth = birth;
            Type = type;
            EmailAddress = emailAddress;
        }
        private DateTime _birth;
        [Required()]
        public DateTime Birth { get => _birth; }

        public Ticket(string name, string address, string cardNo, TicketType type, string emailAddress)
        {
            this.Name = name;
            this.Address = address;
            this.CardNo = cardNo;
            this.Type = type;
            this.EmailAddress = emailAddress;

        }
        [StringLength(64, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 64 character in length.")]

        public string Name { get; set; }
        [Required()]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "Address must be between 2 and 64 character in length.")]
        public string Address { get; set; }
        [Required()]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "CardNo must be between 2 and 64 character in length.")]
        public string CardNo { get; set; }
        [Required()]

        public TicketType Type { get; set; }
        [Required()]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Range(1, 150, ErrorMessage = "Age is not valid")]
        public int Age
        {
            get => _birth.Year == DateTime.Now.Year ? 1 : DateTime.Now.Year - _birth.Year;
        }

        public decimal Payment
        {
            get
            {
                if (Age >= 7)
                {
                    return Type == TicketType.Normal ? 3000000 : 4000000;
                }
                return Type == TicketType.Normal ? 700000 : 1500000;
            }
        }
        public void InputData()
        {

            Console.Write("Enter name:= ");
            Name = Console.ReadLine();
            Console.Write("Enter address:= ");
            Address = Console.ReadLine();
            Console.Write("Enter CardNo:= ");
            CardNo = Console.ReadLine();
            Console.WriteLine("Nhập ngày tháng năm sinh: ");
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ngày: ");
            int day = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Tháng: ");
            int month = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Năm: ");
            int year = Int32.Parse(Console.ReadLine());
            
            _birth = new DateTime(year, month, day);
            Console.WriteLine("Enter TypeTicket (Normal=0,Vip=1):= ");
            string type = (Console.ReadLine());

            if (type == "0")
            {

                Type = TicketType.Normal;
            }
            else if (type == "1")
            {
                Type = TicketType.Vip;
            }
            else
            {
                Type = TicketType.Error;
            }
            
            Console.Write("Nhập địa chỉ Email:= ");
            EmailAddress = Console.ReadLine();



        }
        public void OutputData()
        {      
            Console.WriteLine($"Dữ liệu được lưu thành công.Thành tiền:= {Payment}");
        }
    }
}