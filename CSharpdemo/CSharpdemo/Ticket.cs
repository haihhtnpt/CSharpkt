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
        public Ticket(DateTime birth,TicketType type)
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
        [Required()]
        public string Name { get; set; }
        [Required()]
        public string Address { get; set; }
        [Required()]
        public string CardNo { get; set; }
        [Required()]
        public TicketType Type { get; set; }
        [Required]
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
            Name = Convert.ToString(Console.ReadLine());
            Console.Write("Enter address:= ");
            Address = Convert.ToString(Console.ReadLine());
            Console.Write("Enter CardNo:= ");
            CardNo = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhập ngày tháng năm sinh: ");
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ngày: ");
            int day = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Tháng: ");
            int month = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Năm: ");
            int year = Int32.Parse(Console.ReadLine());
            // DateTime Birth = new DateTime(year,month,day); 
            _birth = new DateTime(year, month, day);
            Console.WriteLine("Enter TypeTicket (Normal=0,Vip=1):= ");
            string type = (Console.ReadLine());
            TicketType ticketTypeENum;
            if (type == "0")
            {
                ticketTypeENum = TicketType.Vip;
            }
            else if (type == "1")
            {
                ticketTypeENum = TicketType.Normal;
            }
            else
                throw new ApplicationException("Cú pháp nhập vào không hợp lệ. Yêu cầu chỉ được chọn 1 hoặc 2.");

            Console.Write("nhap dia chi email:= ");
            EmailAddress = Convert.ToString(Console.ReadLine());



        }
        public void OutputData()
        {

          
            Console.WriteLine($"Giá vé lá:= {Payment}");
        }
    }
}